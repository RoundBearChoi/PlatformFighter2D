using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "StateFactory", menuName = "InfiniteRunner/StateFactory/StateFactory")]
    public class StateFactory : ScriptableObject
    {
        public void New_Runner_Idle(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new Runner_Idle(unit, userInput));
        }
    }
}