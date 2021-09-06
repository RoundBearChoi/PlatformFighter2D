using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class ConnectedPlayerInfo : MonoBehaviour
    {
        [SerializeField]
        Text _playerNumber = null;

        [SerializeField]
        Text _serverIndicator = null;
        
        public void SetPlayerNumber(string playerNumber)
        {
            _playerNumber.text = playerNumber;
        }
    }
}