using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Server
{
    public class ServerController : MonoBehaviour
    {
        public Clients clients = null;
        public delegate void PacketHandler(int _fromClient, Packet _packet);
        public Dictionary<int, PacketHandler> packetHandlers;

        System.Net.Sockets.TcpListener _tcpListener = null;
        System.Net.Sockets.UdpClient _udpClient = null;

        string _localIP = string.Empty;
        string _publicIP = string.Empty;

        public static int PORT
        {
            get
            {
                return 26950;
            }
        }

        public void OpenServer()
        {
            InitServer();

            _tcpListener = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, PORT);
            _tcpListener.Start();
            _tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);

            _udpClient = new System.Net.Sockets.UdpClient(PORT);
            _udpClient.BeginReceive(ServerCallBackUDP, null);

            Debugger.Log("server started on port: " + PORT);

            GetLocalIP();
            GetPublicIP();
        }

        public void GetLocalIP()
        {
            System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

            foreach (System.Net.IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    _localIP = ip.ToString();
                }
            }

            Debugger.Log("local ip: " + _localIP);
            BaseMessage message = new ShowPrivateIP(_localIP);
            message.Register();
        }

        public async void GetPublicIP()
        {
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            _publicIP = await httpClient.GetStringAsync("https://api.ipify.org");

            Debugger.Log("public ip: " + _publicIP);
            BaseMessage message = new ShowPublicIP(_publicIP);
            message.Register();
        }

        private void TCPConnectCallback(System.IAsyncResult result)
        {
            if (BaseInitializer.current != null)
            {
                if (BaseInitializer.current.GetStage() is HostGameStage)
                {
                    System.Net.Sockets.TcpClient tcpClient = _tcpListener.EndAcceptTcpClient(result);
                    _tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);

                    Debugger.Log("incoming connection from: " + (tcpClient.Client.RemoteEndPoint));

                    bool connected = clients.AddClient(tcpClient);

                    if (!connected)
                    {
                        Debugger.Log(tcpClient.Client.RemoteEndPoint + "failed to connect");
                    }
                }
                else
                {
                    Debugger.Log("no server lobby");
                }
            }
        }

        private void ServerCallBackUDP(System.IAsyncResult result)
        {
            try
            {
                System.Net.IPEndPoint clientEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
                byte[] received = _udpClient.EndReceive(result, ref clientEndPoint);
                _udpClient.BeginReceive(ServerCallBackUDP, null);

                if (received.Length < 4)
                {
                    return;
                }

                using (Packet packet = new Packet(received))
                {
                    int clientId = packet.ReadInt();

                    ClientData clientData = clients.GetClientData(clientId);

                    if (clientData.serverUDP.ipEndPoint == null)
                    {
                        // If this is a new connection
                        clientData.serverUDP.Connect(clientEndPoint);
                        return;
                    }

                    if (clientData.serverUDP.ipEndPoint.ToString() == clientEndPoint.ToString())
                    {
                        // Ensures that the client is not being impersonated by another by sending a false clientID
                        clientData.serverUDP.HandleData(packet);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.Log("system error receiving udp data: " + e);
            }
        }

        public void BeginServerUDPSend(System.Net.IPEndPoint clientEndPoint, Packet packet)
        {
            try
            {
                if (clientEndPoint != null)
                {
                    _udpClient.BeginSend(packet.ToArray(), packet.Length(), clientEndPoint, null, null);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log("system error error sending data to " + clientEndPoint + " via UDP: " + e);
            }
        }

        private void InitServer()
        {
            Clients.ResetConnectCount();

            if (clients == null)
            {
                clients = new Clients();
            }

            packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)ClientPackets.welcomeReceived, ServerHandle.WelcomeReceived },
                { (int)ClientPackets.client_input, ServerHandle.HandleClientInput },
            };
        }

        public void EndServer()
        {
            clients.DisconnectClients();

            _tcpListener.Stop();
            _udpClient.Close();

            Debugger.Log("server ended");
        }
    }
}