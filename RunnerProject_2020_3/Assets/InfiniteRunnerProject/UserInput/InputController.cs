using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class InputController
    {
        private List<UserInput> _listUserInputs = new List<UserInput>();

        [SerializeField]
        private int _inputIndex = 0;

        public UserInput GetUserInput(int index)
        {
            if (index < _listUserInputs.Count)
            {
                return _listUserInputs[index];
            }

            return null;
        }

        public UserInput GetUserInput()
        {
            if (_inputIndex < _listUserInputs.Count)
            {
                return _listUserInputs[_inputIndex];
            }

            return null;
        }

        public void UpdateIndexInput()
        {
            if (_inputIndex < _listUserInputs.Count)
            {
                _listUserInputs[_inputIndex].OnUpdate();
            }
        }
    }
}