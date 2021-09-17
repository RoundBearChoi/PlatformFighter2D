using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientTCP
    {
        System.Net.Sockets.TcpClient _socket;
        System.Net.Sockets.NetworkStream _stream;
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

                RB.Network.Packet packet = HandleData(_data);
                packet.Dispose();

                _stream.BeginRead(_receivedBuffer, 0, _dataBufferSize, ReceiveCallback, null);
            }
            catch
            {
                ClientManager.CURRENT.DisconnectClient();
            }
        }

        private RB.Network.Packet HandleData(byte[] _data)
        {
            int _packetLength = 0;

            RB.Network.Packet receivedData = new RB.Network.Packet();
            receivedData.SetBytes(_data);

            if (receivedData.UnreadLength() >= 4)
            {
                _packetLength = receivedData.ReadInt();

                if (_packetLength <= 0)
                {
                    return receivedData;
                }
            }

            while (_packetLength > 0 && _packetLength <= receivedData.UnreadLength())
            {
                byte[] _packetBytes = receivedData.ReadBytes(_packetLength);

                RB.Network.ThreadControl.ExecuteOnMainThread(() =>
                {
                    using (RB.Network.Packet _packet = new RB.Network.Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        ClientController.packetHandlers[_packetId](_packet);
                    }
                });

                _packetLength = 0;

                if (receivedData.UnreadLength() >= 4)
                {
                    _packetLength = receivedData.ReadInt();

                    if (_packetLength <= 0)
                    {
                        return receivedData;
                    }
                }
            }

            if (_packetLength <= 1)
            {
                return receivedData;
            }

            return receivedData;
        }
    }
}