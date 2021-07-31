using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class InputController
    {
        [SerializeField]
        private InputType _inputType = InputType.NONE;

        [SerializeField]
        private List<UserInput> _listUserInputs = new List<UserInput>();

        public UserInput AddInput()
        {
            if (_listUserInputs.Count < (int)InputType.PLAYER_FOUR)
            {
                InputType inputType = (InputType)(_listUserInputs.Count + 1);
                _listUserInputs.Add(new UserInput(inputType));
                return _listUserInputs[_listUserInputs.Count - 1];
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