using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientTCP
    {
        public System.Net.Sockets.TcpClient socket;
        
        System.Net.Sockets.NetworkStream _stream;
        RB.Network.Packet _receivedData;
        byte[] _receivedBuffer;

        int _dataBufferSize = 0;
        int _port = 0;

        public void Connect(string ip, int dataBufferSize, int port)
        {
            _dataBufferSize = dataBufferSize;
            _port = port;

            socket = new System.Net.Sockets.TcpClient
            {
                ReceiveBufferSize = _dataBufferSize,
                SendBufferSize = _dataBufferSize
            };

            _receivedBuffer = new byte[_dataBufferSize];
            socket.BeginConnect(ip, _port, ConnectCallback, socket);
        }

        private void ConnectCallback(System.IAsyncResult _result)
        {
            try
            {
                socket.EndConnect(_result);

                if (!socket.Connected)
                {
                    return;
                }

                _stream = socket.GetStream();

                _receivedData = new RB.Network.Packet();

                _stream.BeginRead(_receivedBuffer, 0, _dataBufferSize, ReceiveCallback, null);
            }
            catch (System.Exception e)
            {
                Debug.Log("attempt failed: " + e);

                RB.Network.ThreadManager.ExecuteOnMainThread(() =>
                {
                    ClientManager.CURRENT.ShowEnterIPUI();
                    ClientManager.CURRENT.QueueConnectionFailedMessage();
                });
            }
        }

        public void SendData(RB.Network.Packet packet)
        {
            try
            {
                if (socket != null)
                {
                    _stream.BeginWrite(packet.ToArray(), 0, packet.Length(), null, null);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log($"Error sending data to server via TCP: {e}");
            }
        }

        private void ReceiveCallback(System.IAsyncResult _result)
        {
            try
            {
                int _byteLength = _stream.EndRead(_result);
                if (_byteLength <= 0)
                {
                    ClientManager.CURRENT.DisconnectClient();
                    return;
                }

                byte[] _data = new byte[_byteLength];
                System.Array.Copy(_receivedBuffer, _data, _byteLength);

                _receivedData.Reset(HandleData(_data)); // Reset receivedData if all data was handled
                _stream.BeginRead(_receivedBuffer, 0, _dataBufferSize, ReceiveCallback, null);
            }
            catch
            {
                ClientManager.CURRENT.DisconnectClient();
                //ClearTCP();
            }
        }

        private bool HandleData(byte[] _data)
        {
            int _packetLength = 0;

            _receivedData.SetBytes(_data);

            if (_receivedData.UnreadLength() >= 4)
            {
                // If client's received data contains a packet
                _packetLength = _receivedData.ReadInt();
                if (_packetLength <= 0)
                {
                    // If packet contains no data
                    return true; // Reset receivedData instance to allow it to be reused
                }
            }

            while (_packetLength > 0 && _packetLength <= _receivedData.UnreadLength())
            {
                // While packet contains data AND packet data length doesn't exceed the length of the packet we're reading
                byte[] _packetBytes = _receivedData.ReadBytes(_packetLength);
                RB.Network.ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (RB.Network.Packet _packet = new RB.Network.Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        ClientController.packetHandlers[_packetId](_packet); // Call appropriate method to handle the packet
                    }
                });

                _packetLength = 0; // Reset packet length
                if (_receivedData.UnreadLength() >= 4)
                {
                    // If client's received data contains another packet
                    _packetLength = _receivedData.ReadInt();
                    if (_packetLength <= 0)
                    {
                        // If packet contains no data
                        return true; // Reset receivedData instance to allow it to be reused
                    }
                }
            }

            if (_packetLength <= 1)
            {
                return true; // Reset receivedData instance to allow it to be reused
            }

            return false;
        }
    }
}