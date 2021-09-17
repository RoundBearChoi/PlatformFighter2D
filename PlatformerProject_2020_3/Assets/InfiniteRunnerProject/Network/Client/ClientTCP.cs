using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientTCP
    {
        System.Net.Sockets.TcpClient _socket;
        System.Net.Sockets.NetworkStream _stream;
        RB.Network.Packet _receivedData;
        byte[] _receivedBuffer;

        int _dataBufferSize = 0;

        public System.Net.Sockets.TcpClient SOCKET
        {
            get
            {
                return _socket;
            }
        }

        public void Connect(string ip, int dataBufferSize)
        {
            _dataBufferSize = dataBufferSize;

            _socket = new System.Net.Sockets.TcpClient
            {
                ReceiveBufferSize = _dataBufferSize,
                SendBufferSize = _dataBufferSize
            };

            _receivedBuffer = new byte[_dataBufferSize];
            _socket.BeginConnect(ip, RB.Server.ServerController.PORT, ConnectCallback, _socket);
        }

        private void ConnectCallback(System.IAsyncResult result)
        {
            try
            {
                _socket.EndConnect(result);

                if (!_socket.Connected)
                {
                    return;
                }

                _receivedData = new RB.Network.Packet();

                _stream = _socket.GetStream();
                _stream.BeginRead(_receivedBuffer, 0, _dataBufferSize, ReceiveCallback, null);
            }
            catch (System.Exception e)
            {
                Debugger.Log("System error attempting to connect: " + e);

                RB.Network.ThreadControl.ExecuteOnMainThread(() =>
                {
                    ClientManager.CURRENT.ShowEnterIPUI();
                });
            }
        }

        public void SendData(RB.Network.Packet packet)
        {
            try
            {
                if (_socket != null)
                {
                    _stream.BeginWrite(packet.ToArray(), 0, packet.Length(), null, null);
                }
            }
            catch (System.Exception e)
            {
                Debugger.Log("System error sending data to server via TCP: " + e);

                RB.Network.ThreadControl.ExecuteOnMainThread(() =>
                {
                    ClientManager.CURRENT.DisconnectClient();
                    BaseInitializer.current.stageTransitioner.AddNextStage(GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.INTRO_STAGE)) as BaseStage);
                });
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
                RB.Network.ThreadControl.ExecuteOnMainThread(() =>
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