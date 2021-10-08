using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class InputDeviceData
    {
        public string deviceName = string.Empty;
        public UnityEngine.InputSystem.Keyboard keyboard = null;
        public UnityEngine.InputSystem.Mouse mouse = null;
        public UnityEngine.InputSystem.Gamepad gamepad = null;
    }
}