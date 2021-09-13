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
        
        public void SetPlayerName(string playerName)
        {
            _playerNumber.text = playerName;
        }

        public void ToggleServerIndicator(bool toggle)
        {
            _serverIndicator.gameObject.SetActive(toggle);
        }

        public bool IsServer()
        {
            if (_serverIndicator.gameObject.activeInHierarchy)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}