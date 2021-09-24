using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientTCP
    {
        System.Net.Sockets.TcpClient _tcpClient;
        System.Net.Sockets.NetworkStream _stream;
        byte[] _receivedBuffer;
        int _dataBufferSize = 0;

        public System.Net.Sockets.TcpClient TCP_CLIENT
        {
            get
            {
                return _tcpClient;
            }
        }

        public void Connect(string ip, int dataBufferSize)
        {
            _dataBufferSize = dataBufferSize;

            _tcpClient = new System.Net.Sockets.TcpClient
            {
                ReceiveBufferSize = _dataBufferSize,
                SendBufferSize = _dataBufferSize
            };

            _receivedBuffer = new byte[_dataBufferSize];
            _tcpClient.BeginConnect(ip, RB.Server.ServerController.PORT, ConnectCallback, _tcpClient);
        }

        private void ConnectCallback(System.IAsyncResult result)
        {
            try
            {
                _tcpClient.EndConnect(result);

                if (!_tcpClient.Connected)
                {
                    return;
                }

                _stream = _tcpClient.GetStream();
                _stream.BeginRead(_receivedBuffer, 0, _dataBufferSize, ClientCallBackTCPConnect, null);
            }
            catch (System.Exception e)
            {
                Debugger.Log("System error attempting to connect: " + e);

                RB.Network.ThreadControl.ExecuteOnMainThread(() =>
                {
                    if (BaseInitializer.current.GetStage() is ConnectingStage)
                    {
                        BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.ENTER_IP_STAGE));
                    }
                });
            }
        }

        public void SendData(RB.Network.Packet packet)
        {
            try
            {
                if (_tcpClient != null)
                {
                    _stream.BeginWrite(packet.ToArray(), 0, packet.Length(), ClientCallBackTCPSend, null);
                }
            }
            catch (System.Exception e)
            {
                Debugger.Log("system error sending TCP to server: " + e);

                ClientManager.CURRENT.EndClient();

                RB.Network.ThreadControl.ExecuteOnMainThread(() =>
                {
                    BaseInitializer.current.stageTransitioner.AddNextStage(GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.INTRO_STAGE)) as BaseStage);
                });
            }
        }

        void ClientCallBackTCPSend(System.IAsyncResult result)
        {
            Debugger.Log("tcp send result: " + result.IsCompleted);
        }

        void ClientCallBackTCPConnect(System.IAsyncResult result)
        {
            try
            {
                int byteLength = _stream.EndRead(result);

                if (byteLength <= 0)
                {
                    Debugger.Log("received 0 bytes from server");

                    ClientManager.CURRENT.EndClient();
                    return;
                }

                byte[] arr = new byte[byteLength];
                System.Array.Copy(_receivedBuffer, arr, byteLength);

                RB.Network.Packet packet = HandleData(arr);

                packet.Dispose();

                _stream.BeginRead(_receivedBuffer, 0, _dataBufferSize, ClientCallBackTCPConnect, null);
            }
            catch (System.Exception e)
            {
                Debugger.Log("system error on tcp send: " + e);

                ClientManager.CURRENT.EndClient();
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