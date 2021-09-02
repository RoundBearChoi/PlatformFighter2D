using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerIdleOnGround : StateComponent
    {
        public TriggerIdleOnGround(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                _unit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (!_unit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_RIGHT) && _unit.unitData.facingRight)
                {
                    _unit.unitData.listNextStates.Add(new LittleRed_Idle(_unit));
                }

                if (!_unit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_LEFT) && !_unit.unitData.facingRight)
                {
                    _unit.unitData.listNextStates.Add(new LittleRed_Idle(_unit));
                }
            }
        }
    }
}