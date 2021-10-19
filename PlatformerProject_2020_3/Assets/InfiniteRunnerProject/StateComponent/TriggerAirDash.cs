using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerAirDash : StateComponent
    {
        int _indexRequirement = 0;

        public TriggerAirDash(UnitState unitState, int indexRequirement)
        {
            _indexRequirement = indexRequirement;
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = UNIT.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (!UNIT_DATA.collisionEnters.IsTouchingGround(CollisionType.BOTTOM) &&
                    !UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM) &&
                    !UNIT_DATA.airControl.DashTriggered &&
                    ani.SPRITE_INDEX >= _indexRequirement &&
                    UNIT.iStateController.GetCurrentState().fixedUpdateCount >= 1)
                {
                    if (UNIT.USER_INPUT.commands.MovementKey_Left())
                    {
                        Dash(CollisionType.LEFT);
                    }
                    else if (UNIT.USER_INPUT.commands.MovementKey_Right())
                    {
                        Dash(CollisionType.RIGHT);
                    }
                }
            }
        }

        void Dash(CollisionType moveTo)
        {
            if (UNIT_DATA.collisionStays.GetCollisionData(moveTo).Count == 0)
            {
                if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.SHIFT, true))
                {
                    if (moveTo == CollisionType.LEFT)
                    {
                        UNIT.facingRight = false;

                        if (UNIT_DATA.airControl.HORIZONTAL_MOMENTUM > 0f)
                        {
                            UNIT_DATA.airControl.SetMomentum(-0.01f);
                        }
                    }
                    else if (moveTo == CollisionType.RIGHT)
                    {
                        UNIT.facingRight = true;

                        if (UNIT_DATA.airControl.HORIZONTAL_MOMENTUM < 0f)
                        {
                            UNIT_DATA.airControl.SetMomentum(0.01f);
                        }
                    }

                    UNIT.listNextStates.Add(new LittleRed_Dash());
                }
            }
        }
    }
}