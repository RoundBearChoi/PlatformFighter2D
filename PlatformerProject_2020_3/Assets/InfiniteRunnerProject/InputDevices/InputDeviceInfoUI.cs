using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class InputDeviceInfoUI : MonoBehaviour
    {
        [SerializeField]
        string _deviceName = string.Empty;

        [SerializeField]
        Image _pcImage = null;

        [SerializeField]
        Image _psImage = null;

        [SerializeField]
        Text _deviceNameText = null;

        Image _deviceImage = null;

        [SerializeField]
        Image _downArrowImage = null;

        [SerializeField]
        bool _deviceDetected = false;

        [SerializeField]
        bool _upIsPressed = false;

        [SerializeField]
        bool _downIsPressed = false;

        UnityEngine.InputSystem.Keyboard _keyboard = null;
        UnityEngine.InputSystem.Mouse _mouse = null;
        UnityEngine.InputSystem.Gamepad _gamepad = null;

        public Image DEVICE_IMAGE
        {
            get
            {
                return _deviceImage;
            }
        }

        public bool DEVICE_DETECTED
        {
            get
            {
                return _deviceDetected;
            }
        }

        public string DEVICE_NAME
        {
            get
            {
                return _deviceName;
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
            _deviceName = _keyboard.name;
            _deviceDetected = true;
            _downArrowImage.enabled = true;

            _psImage.enabled = false;
            _deviceImage = _pcImage;

            _deviceNameText.text = "KEYBOARD & MOUSE";
        }

        public void SetInputDevice(UnityEngine.InputSystem.Mouse mouse)
        {
            _mouse = mouse;
            _deviceDetected = true;
            _downArrowImage.enabled = true;

            _psImage.enabled = false;
            _deviceImage = _pcImage;
        }

        public void SetInputDevice(UnityEngine.InputSystem.Gamepad gamepad, int gamepadIndex)
        {
            _gamepad = gamepad;
            _deviceName = gamepad.name;
            _deviceName = gamepad.name;
            _deviceDetected = true;
            _downArrowImage.enabled = true;

            _pcImage.enabled = false;
            _deviceImage = _psImage;

            _deviceNameText.text = "CONTROLLER " + (gamepadIndex + 1);
        }

        public void NoDeviceDetected()
        {
            _pcImage.enabled = false;
            _psImage.enabled = false;
            _downArrowImage.enabled = false;
            _deviceNameText.text = string.Empty;
        }

        public void OnUpdate()
        {
            UpdatePresses();
            UpdateSelection();

            if (_deviceDetected)
            {
                if (!IsSelected())
                {
                    DEVICE_IMAGE.transform.localPosition = Vector3.Lerp(DEVICE_IMAGE.transform.localPosition, Vector3.zero, Time.deltaTime * BaseInitializer.current.fighterDataSO.InputDeviceIconMoveSpeed);

                    if (_deviceDetected)
                    {
                        _downArrowImage.enabled = true;
                    }
                }
            }
        }

        void UpdatePresses()
        {
            if (_keyboard != null)
            {
                if (_keyboard.downArrowKey.isPressed)
                {
                    _downIsPressed = true;
                }
                else
                {
                    _downIsPressed = false;
                }

                if (_keyboard.upArrowKey.isPressed)
                {
                    _upIsPressed = true;
                }
                else
                {
                    _upIsPressed = false;
                }
            }

            if (_gamepad != null)
            {
                if (_gamepad.leftStick.down.isPressed || _gamepad.dpad.down.isPressed)
                {
                    _downIsPressed = true;
                }
                else if (_gamepad.leftStick.down.isPressed == false && _gamepad.dpad.down.isPressed == false)
                {
                    _downIsPressed = false;
                }

                if (_gamepad.leftStick.up.isPressed || _gamepad.dpad.up.isPressed)
                {
                    _upIsPressed = true;
                }
                else if (_gamepad.leftStick.up.isPressed == false && _gamepad.dpad.up.isPressed == false)
                {
                    _upIsPressed = false;
                }
            }
        }

        void UpdateSelection()
        {
            if (_downIsPressed)
            {
                _downArrowImage.enabled = false;

                for (int i = 0; i < BaseInitializer.current.arrInputDeviceUI.Length; i++)
                {
                    if (BaseInitializer.current.arrInputDeviceUI[i] == this)
                    {
                        break;
                    }

                    if (BaseInitializer.current.arrInputDeviceUI[i] == null)
                    {
                        BaseInitializer.current.arrInputDeviceUI[i] = this;
                        break;
                    }
                }
            }

            if (_upIsPressed)
            {
                for (int i = 0; i < BaseInitializer.current.arrInputDeviceUI.Length; i++)
                {
                    if (BaseInitializer.current.arrInputDeviceUI[i] == this)
                    {
                        BaseInitializer.current.arrInputDeviceUI[i] = null;
                        break;
                    }
                }
            }
        }

        bool IsSelected()
        {
            for (int i = 0; i < BaseInitializer.current.arrInputDeviceUI.Length; i++)
            {
                if (BaseInitializer.current.arrInputDeviceUI[i] == this)
                {
                    return true;
                }
            }

            return false;
        }
    }
}