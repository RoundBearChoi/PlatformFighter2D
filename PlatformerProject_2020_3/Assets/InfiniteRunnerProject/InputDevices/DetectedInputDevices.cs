using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DetectedInputDevices : UIElement
    {
        [Space(10)]
        [SerializeField]
        List<InputDeviceInfoUI> _listInputDeviceInfo = new List<InputDeviceInfoUI>();

        public override void InitElement()
        {
            _listInputDeviceInfo.Clear();

            InputDeviceInfoUI[] arr = this.gameObject.GetComponentsInChildren<InputDeviceInfoUI>();

            foreach(InputDeviceInfoUI info in arr)
            {
                _listInputDeviceInfo.Add(info);
                info.ShowDeviceIcon();
            }

            if (UnityEngine.InputSystem.Keyboard.current != null && UnityEngine.InputSystem.Mouse.current != null)
            {
                _listInputDeviceInfo[0].SetInputDevice(UnityEngine.InputSystem.Keyboard.current);
                _listInputDeviceInfo[0].SetInputDevice(UnityEngine.InputSystem.Mouse.current);
            }

            for (int i = 0; i < UnityEngine.InputSystem.Gamepad.all.Count; i++)
            {
                if (_listInputDeviceInfo.Count > i + 1)
                {
                    Debugger.Log("gamepad detected: " + UnityEngine.InputSystem.Gamepad.all[i].name);
                    _listInputDeviceInfo[i + 1].SetInputDevice(UnityEngine.InputSystem.Gamepad.all[i]);
                }
            }

            foreach(InputDeviceInfoUI info in _listInputDeviceInfo)
            {
                if (!info.DEVICE_DETECTED)
                {
                    info.NoDeviceDetected();
                }
            }
        }

        public override void OnUpdate()
        {
            foreach(InputDeviceInfoUI info in _listInputDeviceInfo)
            {
                info.OnUpdate();
            }
        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnLateUpdate()
        {

        }
    }
}