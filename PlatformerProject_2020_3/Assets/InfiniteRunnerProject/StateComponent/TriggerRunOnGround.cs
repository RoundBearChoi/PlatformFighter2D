using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerRunOnGround : StateComponent
    {
        public TriggerRunOnGround(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                _unit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false))
                {
                    _unit.unitData.listNextStates.Add(new LittleRed_Run(_unit));
                }

                if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false))
                {
                    _unit.unitData.listNextStates.Add(new LittleRed_Run(_unit));
                }
            }
        }
    }
}