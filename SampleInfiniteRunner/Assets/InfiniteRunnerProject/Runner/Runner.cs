using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : GameElement
    {
        private UserInput userInput = null;

        public StateController stateController = null;

        public override void Init()
        {
            stateController = new StateController(new Runner_Idle());
            elementData = new GameElementData(this.transform);
        }

        public override void OnFixedUpdate()
        {
            stateController.TransitionToNextState();
            stateController.UpdateState(userInput, elementData);
        }

        public void SetUserInput(UserInput _userInput)
        {
            userInput = _userInput;
        }
    }
}