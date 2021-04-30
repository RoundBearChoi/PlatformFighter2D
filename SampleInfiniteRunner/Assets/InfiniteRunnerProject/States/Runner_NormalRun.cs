using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_NormalRun : State
    {
        public Runner_NormalRun()
        {
            Debugger.Log("new state: Runner_NormalRun");
        }

        public override void Update(UserInput userInput, Transform objTransform)
        {
            objTransform.position += new Vector3(0.01f, 0f, 0f);
        }
    }
}