using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class InputController
    {
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

        public UserInput GetLatestUserInput()
        {
            if (_listUserInputs.Count > 0)
            {
                return _listUserInputs[_listUserInputs.Count - 1];
            }

            return null;
        }

        public UserInput GetUserInput(InputType inputType)
        {
            foreach(UserInput input in _listUserInputs)
            {
                if (input.INPUT_TYPE == inputType)
                {
                    return input;
                }
            }

            return null;
        }

        public UserInput GetUserInput(int index)
        {
            if (_listUserInputs.Count > index)
            {
                return _listUserInputs[index];
            }

            return null;
        }

        public void ClearAllKeysAndButtons()
        {
            foreach(UserInput input in _listUserInputs)
            {
                input.commands.ClearKeyPressDictionary();
            }
        }

        public int GetCount()
        {
            return _listUserInputs.Count;
        }
    }
}