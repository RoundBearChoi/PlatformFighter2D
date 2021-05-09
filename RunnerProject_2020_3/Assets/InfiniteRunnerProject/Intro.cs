using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    public class Intro : MonoBehaviour
    {
        public bool EnterPressed = false;

        Keyboard _keyboard = null;
        Camera _mainCam = null;

        private void Start()
        {
            _keyboard = Keyboard.current;

            _mainCam = FindObjectOfType<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);
        }

        private void Update()
        {
            if (_keyboard.enterKey.wasPressedThisFrame)
            {
                EnterPressed = true;
            }
        }
    }
}