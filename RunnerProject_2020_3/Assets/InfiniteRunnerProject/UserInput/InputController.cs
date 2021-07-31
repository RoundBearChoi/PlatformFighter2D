using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class InputController
    {
        private List<UserInput> _listUserInputs = new List<UserInput>();

        [SerializeField]
        private InputType _inputType = InputType.NONE;

        public UserInput AddInput()
        {
            if (_listUserInputs.Count < (int)InputType.FOUR)
            {
                _listUserInputs.Add(new UserInput());
                _listUserInputs.Add(new UserInput());
            }

            return null;
        }

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
            return _listUserInputs[GetInputTypeIndex()];
        }

        public void UpdateIndexInput()
        {
            _listUserInputs[GetInputTypeIndex()].OnUpdate();
        }

        int GetInputTypeIndex()
        {
            if ((int)_inputType < _listUserInputs.Count)
            {
                return (int)_inputType;
            }
            else
            {
                return 0;
            }
        }
    }
}