using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class NormalRunToFall : StateComponent
    {
        UserInput _userInput = null;

        public NormalRunToFall(Unit unit, UserInput userInput)
        {
            _unit = unit;
            _userInput = userInput;
        }

        public override void Update()
        {
            //in the air
            if (_unit.unitData.collisionStays.GetCount() == 0)
            {
                //falling
                if (_unit.unitData.rigidBody2D.velocity.y < 0f)
                {
                    _unit.unitData.listNextStates.Add(new Runner_Jump_Fall(_unit, _userInput));
                }
            }
        }
    }
}