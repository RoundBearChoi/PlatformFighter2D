using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using RB.Network;

namespace RB.Client
{
    public class ClientHandle : MonoBehaviour
    {
        public static void Welcome(Packet _packet)
        {
            string _msg = _packet.ReadString();
            int _myId = _packet.ReadInt();

            Debug.Log($"Message from server: {_msg}");
            Client.instance.myId = _myId;
            ClientSend.WelcomeReceived();

            // Now that we have the client's id, connect UDP
            Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
        }

        public static void SpawnPlayer(Packet _packet)
        {
            int _id = _packet.ReadInt();
            string _username = _packet.ReadString();
            Vector3 _position = _packet.ReadVector3();
            Quaternion _rotation = _packet.ReadQuaternion();

            GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
        }

        public static void PlayerPosition(Packet _packet)
        {
            int id = _packet.ReadInt();
            

            if (GameManager.players.ContainsKey(id))
            {
                Vector3 position = _packet.ReadVector3();
                GameManager.players[id].transform.position = position;
            }
        }

        //public static void PlayerRotation(Packet _packet)
        //{
        //    int _id = _packet.ReadInt();
        //    Quaternion _rotation = _packet.ReadQuaternion();
        //
        //    GameManager.players[_id].transform.rotation = _rotation;
        //}
    }
}