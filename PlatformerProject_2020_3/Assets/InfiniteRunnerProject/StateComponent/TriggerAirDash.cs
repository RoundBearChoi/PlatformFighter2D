using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerAirDash : StateComponent
    {
        public TriggerAirDash(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (!_unit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM) &&
                !_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) &&
                !_unit.unitData.airControl.DashTriggered)
            {
                uint fixedUpdateCount = _unit.iStateController.GetCurrentState().fixedUpdateCount;

                if (_unit.USER_INPUT.commands.ContainsPress(CommandType.SHIFT, true) && fixedUpdateCount >= 1)
                {
                    if (_unit.USER_INPUT.commands.MovementKey_Left())
                    {
                        _unit.unitData.facingRight = false;

                        if (_unit.unitData.airControl.HORIZONTAL_MOMENTUM > 0f)
                        {
                            _unit.unitData.airControl.SetMomentum(-0.01f);
                        }

                        Dash(CollisionType.LEFT, CommandType.MOVE_LEFT);
                    }
                    else if (_unit.USER_INPUT.commands.MovementKey_Right())
                    {
                        if (_unit.unitData.airControl.HORIZONTAL_MOMENTUM < 0f)
                        {
                            _unit.unitData.airControl.SetMomentum(0.01f);
                        }

                        _unit.unitData.facingRight = true;
                        Dash(CollisionType.RIGHT, CommandType.MOVE_RIGHT);
                    }
                }
            }
        }

        void Dash(CollisionType openSide, CommandType moveSide)
        {
            if (_unit.unitData.collisionStays.GetCollisionData(openSide).Count == 0)
            {
                if (_unit.USER_INPUT.commands.ContainsPress(moveSide, false))
                {
                    _unit.unitData.listNextStates.Add(new LittleRed_Dash(_unit));
                }
            }
        }
    }
}