using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRedUppercut : UnitState
    {
        private bool initialFaceRight = true;

        public LittleRedUppercut(Unit unit)
        {
            ownerUnit = unit;
            initialFaceRight = unit.unitData.facingRight;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, BaseInitializer.current.fighterDataSO.AttackASlowDownPercentage));
            _listStateComponents.Add(new DelayedJump(ownerUnit, BaseInitializer.current.fighterDataSO.VerticalJumpForce * 0.8f, 3));
            _listStateComponents.Add(new UpdateAirMovementOnMomentum(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_UPPERCUT);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            SpriteAnimation ani = ownerUnit.unitData.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                float forwardVelocity = 0f;

                if (ani.SPRITE_INDEX >= 4)
                {
                    if (ownerUnit.unitData.facingRight)
                    {
                        forwardVelocity = 2.5f;
                    }
                    else
                    {
                        forwardVelocity = -2.5f;
                    }
                }
                else if (ani.SPRITE_INDEX >= 8)
                {
                    if (ownerUnit.unitData.facingRight)
                    {
                        forwardVelocity = 1f;
                    }
                    else
                    {
                        forwardVelocity = -1f;
                    }
                }
                else if (ani.SPRITE_INDEX >= 12)
                {
                    if (ownerUnit.unitData.facingRight)
                    {
                        forwardVelocity = 0.25f;
                    }
                    else
                    {
                        forwardVelocity = -0.25f;
                    }
                }

                ownerUnit.unitData.airControl.SetMomentum(forwardVelocity);

                if (ani.IsOnEnd())
                {
                    if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                    {
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                    }
                    else
                    {
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(ownerUnit));
                    }
                }
            }
        }

        public override void OnExit()
        {
            if (initialFaceRight)
            {
                ownerUnit.unitData.airControl.SetMomentum(-0.01f);
                ownerUnit.unitData.facingRight = false;
            }
            else
            {
                ownerUnit.unitData.airControl.SetMomentum(0.01f);
                ownerUnit.unitData.facingRight = true;
            }
        }
    }
}