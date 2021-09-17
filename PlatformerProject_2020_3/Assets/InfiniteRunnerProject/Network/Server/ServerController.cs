using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Server
{
    public class ServerController : MonoBehaviour
    {
        public Clients connectedClients = null;
        public delegate void PacketHandler(int _fromClient, Packet _packet);
        public Dictionary<int, PacketHandler> packetHandlers;

        System.Net.Sockets.TcpListener tcpListener = null;
        System.Net.Sockets.UdpClient udpListener = null;

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

            tcpListener = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, PORT);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);

            udpListener = new System.Net.Sockets.UdpClient(PORT);
            udpListener.BeginReceive(UDPReceiveCallback, null);

            Debugger.Log($"Server started on port {PORT}.");

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

        private void TCPConnectCallback(IAsyncResult result)
        {
            if (BaseInitializer.current != null)
            {
                if (BaseInitializer.current.GetStage() is HostGameStage)
                {
                    System.Net.Sockets.TcpClient tcpClient = tcpListener.EndAcceptTcpClient(result);
                    tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);

                    Debugger.Log("incoming connection from: " + (tcpClient.Client.RemoteEndPoint));

                    bool connected = connectedClients.AddClient(tcpClient);

                    if (!connected)
                    {
                        Debugger.Log($"{tcpClient.Client.RemoteEndPoint} failed to connect");
                    }
                }
                else
                {
                    Debugger.Log("no server lobby");
                }
            }
        }

        private void UDPReceiveCallback(IAsyncResult result)
        {
            try
            {
                System.Net.IPEndPoint clientEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
                byte[] received = udpListener.EndReceive(result, ref clientEndPoint);
                udpListener.BeginReceive(UDPReceiveCallback, null);

                if (received.Length < 4)
                {
                    return;
                }

                using (Packet packet = new Packet(received))
                {
                    int clientId = packet.ReadInt();

                    ClientData clientData = connectedClients.GetClientData(clientId);

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
            catch (Exception _ex)
            {
                Debug.Log($"Error receiving UDP data: {_ex}");
            }
        }

        public void SendUDPData(System.Net.IPEndPoint clientEndPoint, Packet packet)
        {
            try
            {
                if (clientEndPoint != null)
                {
                    udpListener.BeginSend(packet.ToArray(), packet.Length(), clientEndPoint, null, null);
                }
            }
            catch (Exception _ex)
            {
                Debug.Log($"Error sending data to {clientEndPoint} via UDP: {_ex}");
            }
        }

        private void InitServer()
        {
            Clients.ResetConnectCount();

            if (connectedClients == null)
            {
                connectedClients = new Clients();
            }

            packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)ClientPackets.welcomeReceived, ServerHandle.WelcomeReceived },
                { (int)ClientPackets.client_input, ServerHandle.HandleClientInput },
                { (int)ClientPackets.udp_check, ServerHandle.HandleUDPCheck },
            };
            Debug.Log("Initialized packets.");
        }

        public void Stop()
        {
            tcpListener.Stop();
            udpListener.Close();
        }
    }
}