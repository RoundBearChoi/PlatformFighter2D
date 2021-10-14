using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Sirenix.OdinInspector;

namespace RB
{
    public class PressesDebug : SerializedMonoBehaviour
    {
        public Dictionary<CommandType, List<ButtonControl>> allCommands = new Dictionary<CommandType, List<ButtonControl>>();
        public Dictionary<ButtonControl, bool[]> presses = new Dictionary<ButtonControl, bool[]>();
    }
}