using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace RB
{
    public class InputDeviceInfoUI : MonoBehaviour
    {
        [SerializeField]
        string _deviceName = string.Empty;

        [SerializeField]
        public DeviceImage deviceImage = new DeviceImage();

        [SerializeField]
        public DownButton downButton = new DownButton();

        [SerializeField]
        bool _deviceDetected = false;

        [SerializeField]
        bool _upIsPressed = false;

        [SerializeField]
        bool _downIsPressed = false;

        Keyboard _keyboard = null;
        Mouse _mouse = null;
        Gamepad _gamepad = null;

        public bool DEVICE_DETECTED { get { return _deviceDetected; } }
        public string DEVICE_NAME { get { return _deviceName; } }
        public Keyboard KEYBOARD { get { return _keyboard; } }
        public Mouse MOUSE { get { return _mouse; } }
        public Gamepad GAMEPAD { get { return _gamepad; } }

        public void Init()
        {
            _keyboard = null;
            _mouse = null;
            _gamepad = null;

            foreach (Transform t in this.GetComponentsInChildren<Transform>())
            {
                if (t.name == "DeviceImage")
                {
                    deviceImage.Init(t);
                    break;
                }
            }

            foreach (Transform t in this.GetComponentsInChildren<Transform>())
            {
                if (t.name == "DownButton")
                {
                    downButton.Init(t);
                    break;
                }
            }
        }

        public void SetInputDevice(UnityEngine.InputSystem.Keyboard keyboard)
        {
            _keyboard = keyboard;
            _deviceName = _keyboard.name;
            _deviceDetected = true;

            deviceImage.TogglePCImage(true);
            deviceImage.TogglePSImage(false);

            downButton.HideImages(false);
        }

        public void SetInputDevice(UnityEngine.InputSystem.Mouse mouse)
        {
            _mouse = mouse;
            _deviceDetected = true;
        }

        public void SetInputDevice(UnityEngine.InputSystem.Gamepad gamepad)
        {
            _gamepad = gamepad;
            _deviceName = gamepad.name;
            _deviceDetected = true;

            deviceImage.TogglePCImage(false);
            deviceImage.TogglePSImage(true);

            downButton.HideImages(false);
        }

        public void NoDeviceDetected()
        {
            deviceImage.TogglePCImage(false);
            deviceImage.TogglePSImage(false);
            deviceImage.TogglePlayerIcon(false);
            deviceImage.SetPlayerIndex(string.Empty);

            downButton.HideImages(true);
        }

        public void OnUpdate()
        {
            UpdatePresses();
            UpdateSelection();

            if (_deviceDetected)
            {
                if (!IsSelected())
                {
                    deviceImage.TRANSFORM.localPosition = Vector3.Lerp(deviceImage.TRANSFORM.localPosition, Vector3.zero, Time.deltaTime * BaseInitializer.CURRENT.fighterDataSO.InputDeviceIconMoveSpeed);
                    downButton.HideImages(false);
                }
            }
        }

        public void OnFixedUpdate()
        {
            downButton.OnFixedUpdate();
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
                downButton.HideImages(true);

                for (int i = 0; i < BaseInitializer.CURRENT.arrInputDeviceUI.Length; i++)
                {
                    if (BaseInitializer.CURRENT.arrInputDeviceUI[i] == this)
                    {
                        break;
                    }

                    if (BaseInitializer.CURRENT.arrInputDeviceUI[i] == null)
                    {
                        BaseInitializer.CURRENT.arrInputDeviceUI[i] = this;
                        break;
                    }
                }
            }

            if (_upIsPressed)
            {
                for (int i = 0; i < BaseInitializer.CURRENT.arrInputDeviceUI.Length; i++)
                {
                    if (BaseInitializer.CURRENT.arrInputDeviceUI[i] == this)
                    {
                        BaseInitializer.CURRENT.arrInputDeviceUI[i] = null;
                        break;
                    }
                }
            }
        }

        bool IsSelected()
        {
            for (int i = 0; i < BaseInitializer.CURRENT.arrInputDeviceUI.Length; i++)
            {
                if (BaseInitializer.CURRENT.arrInputDeviceUI[i] == this)
                {
                    return true;
                }
            }

            return false;
        }
    }
}