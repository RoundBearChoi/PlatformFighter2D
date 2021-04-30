using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : State
    {
        public Runner_Idle()
        {
            Debugger.Log("new state: Idle");
        }

        /*
        public override void Update()
        {

        }
        */

        public override void Update(UserInput userInput, GameElement gameElement)
        {
            nextState = new Runner_NormalRun();
        }
    }
}