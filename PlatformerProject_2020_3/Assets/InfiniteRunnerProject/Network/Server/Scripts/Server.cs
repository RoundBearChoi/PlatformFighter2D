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
        //public ClientData[] clients = null;
        public Clients connectedClients = null;

        public int Port { get; private set; }

        public delegate void PacketHandler(int _fromClient, Packet _packet);
        public Dictionary<int, PacketHandler> packetHandlers;

        TcpListener tcpListener = null;
        UdpClient udpListener = null;

        /// <summary>Starts the server.</summary>
        /// <param name="_maxPlayers">The maximum players that can be connected simultaneously.</param>
        /// <param name="_port">The port to start the server on.</param>
        public void OpenServer(int _port)
        {
            Port = _port;
            InitServer();

            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);

            udpListener = new UdpClient(Port);
            udpListener.BeginReceive(UDPReceiveCallback, null);

            Debug.Log($"Server started on port {Port}.");
        }

        /// <summary>Handles new TCP connections.</summary>
        private void TCPConnectCallback(IAsyncResult result)
        {
            TcpClient tcpClient = tcpListener.EndAcceptTcpClient(result);
            tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);

            Debug.Log("incoming connection from: " + (tcpClient.Client.RemoteEndPoint));

            bool connected = connectedClients.AddClient(tcpClient);

            if (!connected)
            {
                Debug.Log($"{tcpClient.Client.RemoteEndPoint} failed to connect");
            }
        }

        /// <summary>Receives incoming UDP data.</summary>
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

        /// <summary>Sends a packet to the specified endpoint via UDP.</summary>
        /// <param name="_clientEndPoint">The endpoint to send the packet to.</param>
        /// <param name="_packet">The packet to send.</param>
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

        /// <summary>Initializes all necessary server data.</summary>
        private void InitServer()
        {
            if (connectedClients == null)
            {
                connectedClients = new Clients();
            }

            //for (int i = 0; i < clients.Length; i++)
            //{
            //    clients[i] = new ClientData(i);
            //    clients[i].SetUserName("not connected yet");
            //}

            packetHandlers = new Dictionary<int, PacketHandler>()
        {
            { (int)ClientPackets.welcomeReceived, ServerHandle.WelcomeReceived },
            { (int)ClientPackets.playerMovement, ServerHandle.HandleClientInput },
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