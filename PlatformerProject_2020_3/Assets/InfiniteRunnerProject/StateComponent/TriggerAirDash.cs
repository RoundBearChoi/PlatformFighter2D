using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerAirDash : StateComponent
    {
        int _indexRequirement = 0;

        public TriggerAirDash(Unit unit, int indexRequirement)
        {
            _indexRequirement = indexRequirement;
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = _unit.unitData.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (!_unit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM) &&
                    !_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) &&
                    !_unit.unitData.airControl.DashTriggered &&
                    ani.SPRITE_INDEX >= _indexRequirement &&
                    _unit.iStateController.GetCurrentState().fixedUpdateCount >= 1)
                {
                    if (_unit.USER_INPUT.commands.MovementKey_Left())
                    {
                        Dash(CollisionType.LEFT);
                    }
                    else if (_unit.USER_INPUT.commands.MovementKey_Right())
                    {
                        Dash(CollisionType.RIGHT);
                    }
                }
            }
        }

        void Dash(CollisionType moveTo)
        {
            if (_unit.unitData.collisionStays.GetCollisionData(moveTo).Count == 0)
            {
                if (_unit.USER_INPUT.commands.ContainsPress(CommandType.SHIFT, true))
                {
                    if (moveTo == CollisionType.LEFT)
                    {
                        _unit.unitData.facingRight = false;

                        if (_unit.unitData.airControl.HORIZONTAL_MOMENTUM > 0f)
                        {
                            _unit.unitData.airControl.SetMomentum(-0.01f);
                        }
                    }
                    else if (moveTo == CollisionType.RIGHT)
                    {
                        _unit.unitData.facingRight = true;

                        if (_unit.unitData.airControl.HORIZONTAL_MOMENTUM < 0f)
                        {
                            _unit.unitData.airControl.SetMomentum(0.01f);
                        }
                    }

                    _unit.unitData.listNextStates.Add(new LittleRed_Dash(_unit));
                }
            }
        }
    }
}