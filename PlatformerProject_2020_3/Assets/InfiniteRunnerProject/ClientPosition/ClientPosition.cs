using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientPosition : MonoBehaviour
    {
        int _id = 0;

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public void SetID(int id)
        {
            _id = id;
        }
    }
}