using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace RB.Client
{
    public class ClientInputController : MonoBehaviour
    {
        [SerializeField]
        bool[] _inputs = null;

        Keyboard keyboard = null;

        private void Start()
        {
            keyboard = Keyboard.current;
        }

        private void FixedUpdate()
        {
            SendInputToServer();
        }

        /// <summary>Sends player input to the server.</summary>
        private void SendInputToServer()
        {
            if (_inputs == null || _inputs.Length == 0)
            {
                _inputs = new bool[5];
            }

            _inputs[0] = keyboard.wKey.IsPressed();
            _inputs[1] = keyboard.sKey.IsPressed();
            _inputs[2] = keyboard.aKey.IsPressed(); 
            _inputs[3] = keyboard.dKey.IsPressed();
            _inputs[4] = keyboard.spaceKey.IsPressed();

            ClientSend.PlayerMovement(_inputs);
        }
    }
}