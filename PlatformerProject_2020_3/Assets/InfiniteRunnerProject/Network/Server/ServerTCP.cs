using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    [System.Serializable]
    public class ServerTCP
    {
        [SerializeField]
        private int _id;

        public System.Net.Sockets.TcpClient socket;

        int _dataBufferSize = 0;
        System.Net.Sockets.NetworkStream _stream;
        byte[] _receivedBuffer;

        public ServerTCP(int id)
        {
            _id = id;
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public void Connect(System.Net.Sockets.TcpClient incomingSocket, int dataBufferSize)
        {
            socket = incomingSocket;
            socket.ReceiveBufferSize = dataBufferSize;
            socket.SendBufferSize = dataBufferSize;

            _stream = socket.GetStream();

            _dataBufferSize = dataBufferSize;

            _receivedBuffer = new byte[_dataBufferSize];

            _stream.BeginRead(_receivedBuffer, 0, _dataBufferSize, ReceiveCallback, null);

            ServerManager.CURRENT.serverSend.Welcome(_id, "Welcome to the server!");
            ServerManager.CURRENT.serverSend.ClientsConnectionStatus();
        }

        public void SendData(RB.Network.Packet _packet)
        {
            try
            {
                if (socket != null)
                {
                    _stream.BeginWrite(_packet.ToArray(), 0, _packet.Length(), null, null);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log($"Error sending data to player {_id} via TCP: {e}");
            }
        }

        private void ReceiveCallback(System.IAsyncResult result)
        {
            try
            {
                int byteLength = _stream.EndRead(result);

                if (byteLength <= 0)
                {
                    ClientData clientData = ServerManager.CURRENT.serverController.connectedClients.GetClientData(_id);
                    clientData.Disconnect();

                    Debugger.Log("received 0 bytes from client: " + _id);

                    return;
                }

                byte[] arr = new byte[byteLength];
                System.Array.Copy(_receivedBuffer, arr, byteLength);

                RB.Network.Packet packet = HandleData(arr);
                packet.Dispose();

                _stream.BeginRead(_receivedBuffer, 0, _dataBufferSize, ReceiveCallback, null);
            }
            catch (System.Exception e)
            {
                Debug.Log("system error receiving TCP data: " + e);

                ClientData clientData = ServerManager.CURRENT.serverController.connectedClients.GetClientData(_id);
                clientData.Disconnect();
            }
        }

        private RB.Network.Packet HandleData(byte[] data)
        {
            int packetLength = 0;

            RB.Network.Packet receivedData = new RB.Network.Packet();
            receivedData.SetBytes(data);

            if (receivedData.UnreadLength() >= 4)
            {
                // If client's received data contains a packet
                packetLength = receivedData.ReadInt();

                if (packetLength <= 0)
                {
                    return receivedData;
                }
            }

            while (packetLength > 0 && packetLength <= receivedData.UnreadLength())
            {
                // While packet contains data AND packet data length doesn't exceed the length of the packet we're reading
                byte[] _packetBytes = receivedData.ReadBytes(packetLength);

                RB.Network.ThreadControl.ExecuteOnMainThread(() =>
                {
                    using (RB.Network.Packet _packet = new RB.Network.Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        ServerManager.CURRENT.serverController.packetHandlers[_packetId](_id, _packet); // Call appropriate method to handle the packet
                    }
                });

                packetLength = 0;

                if (receivedData.UnreadLength() >= 4)
                {
                    packetLength = receivedData.ReadInt();

                    if (packetLength <= 0)
                    {
                        return receivedData;
                    }
                }
            }

            if (packetLength <= 1)
            {
                return receivedData;
            }

            return receivedData;
        }

        public void Disconnect()
        {
            socket.Close();

            _stream = null;
            //_receivedData = null;
            _receivedBuffer = null;
            socket = null;
        }
    }
}