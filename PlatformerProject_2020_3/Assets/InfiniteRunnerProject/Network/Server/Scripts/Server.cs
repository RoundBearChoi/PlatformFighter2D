using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using RB.Network;

namespace RB.Server
{
    [Serializable]
    public class Server
    {
        readonly int _port = 26950;

        public Clients connectedClients = null;
        public delegate void PacketHandler(int _fromClient, Packet _packet);
        public Dictionary<int, PacketHandler> packetHandlers;

        TcpListener tcpListener = null;
        UdpClient udpListener = null;

        public void OpenServer()
        {
            InitServer();

            tcpListener = new TcpListener(IPAddress.Any, _port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);

            udpListener = new UdpClient(_port);
            udpListener.BeginReceive(UDPReceiveCallback, null);

            Debug.Log($"Server started on port {_port}.");
        }

        private void TCPConnectCallback(IAsyncResult result)
        {
            if (BaseInitializer.current != null)
            {
                if (BaseInitializer.current.GetStage() is HostGameStage)
                {
                    TcpClient tcpClient = tcpListener.EndAcceptTcpClient(result);
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

        private void UDPReceiveCallback(IAsyncResult _result)
        {
            try
            {
                IPEndPoint _clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] _data = udpListener.EndReceive(_result, ref _clientEndPoint);
                udpListener.BeginReceive(UDPReceiveCallback, null);

                if (_data.Length < 4)
                {
                    return;
                }

                using (Packet _packet = new Packet(_data))
                {
                    int clientId = _packet.ReadInt();

                    ClientData data = connectedClients.GetClientData(clientId);

                    if (data.udp.endPoint == null)
                    {
                        // If this is a new connection
                        data.udp.Connect(_clientEndPoint);
                        return;
                    }

                    if (data.udp.endPoint.ToString() == _clientEndPoint.ToString())
                    {
                        // Ensures that the client is not being impersonated by another by sending a false clientID
                        data.udp.HandleData(_packet);
                    }
                }
            }
            catch (Exception _ex)
            {
                Debug.Log($"Error receiving UDP data: {_ex}");
            }
        }

        public void SendUDPData(IPEndPoint _clientEndPoint, Packet _packet)
        {
            try
            {
                if (_clientEndPoint != null)
                {
                    udpListener.BeginSend(_packet.ToArray(), _packet.Length(), _clientEndPoint, null, null);
                }
            }
            catch (Exception _ex)
            {
                Debug.Log($"Error sending data to {_clientEndPoint} via UDP: {_ex}");
            }
        }

        private void InitServer()
        {
            if (connectedClients == null)
            {
                connectedClients = new Clients();
            }

            packetHandlers = new Dictionary<int, PacketHandler>()
        {
            { (int)ClientPackets.welcomeReceived, ServerHandle.WelcomeReceived },
            { (int)ClientPackets.client_input, ServerHandle.HandleClientInput },
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