using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    [System.Serializable]
    public class ClientObject : MonoBehaviour
    {
        [SerializeField]
        int _id = 0;

        [SerializeField]
        Vector3 _pos = new Vector3();

        [SerializeField]
        GameObject _playerPositionSphere = null;

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public Vector3 POSITION
        {
            get
            {
                return _pos;
            }
        }

        public void SetID(int id)
        {
            _id = id;
        }

        public void SetPosition(Vector3 pos)
        {
            _pos = pos;
        }

        public void UpdatePosition()
        {
            _playerPositionSphere.transform.position = _pos;
        }
    }
}