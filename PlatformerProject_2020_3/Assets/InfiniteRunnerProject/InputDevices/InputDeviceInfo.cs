using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class InputDeviceInfo : MonoBehaviour
    {
        [SerializeField]
        InputDeviceType _inputDeviceType = InputDeviceType.NONE;

        [SerializeField]
        Image _pcImage = null;

        [SerializeField]
        Image _psImage = null;

        UnityEngine.InputSystem.Keyboard _keyboard = null;
        UnityEngine.InputSystem.Mouse _mouse = null;
        UnityEngine.InputSystem.Gamepad _gamepad = null;

        public void ShowDeviceIcon()
        {
            _pcImage.enabled = false;
            _psImage.enabled = false;

            if (_inputDeviceType == InputDeviceType.PC)
            {
                _pcImage.enabled = true;
            }

            else if (_inputDeviceType == InputDeviceType.PS4)
            {
                _psImage.enabled = true;
            }
        }

        public UnityEngine.InputSystem.Keyboard KEYBOARD
        {
            get
            {
                return _keyboard;
            }
        }

        public UnityEngine.InputSystem.Mouse MOUSE
        {
            get
            {
                return _mouse;
            }
        }

        public UnityEngine.InputSystem.Gamepad GAMEPAD
        {
            get
            {
                return _gamepad;
            }
        }

        public void SetInputDevice(UnityEngine.InputSystem.Keyboard keyboard)
        {
            _keyboard = keyboard;
        }

        public void SetInputDevice(UnityEngine.InputSystem.Mouse mouse)
        {
            _mouse = mouse;
        }

        public void SetInputDevice(UnityEngine.InputSystem.Gamepad gamepad)
        {
            _gamepad = gamepad;
        }

        public void NoDeviceDetected()
        {
            _pcImage.enabled = false;
            _psImage.enabled = false;
        }
    }
}