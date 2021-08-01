using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_WallSlide : UnitState
    {
        private float _maxFallVelocity = 0f;

        public LittleRed_WallSlide(Unit unit)
        {
            ownerUnit = unit;
            _maxFallVelocity = GameInitializer.current.fighterDataSO.MaxWallSlideFallSpeed;

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_WALLSLIDE);
        }

        public override void OnEnter()
        {
            ownerUnit.unitData.rigidBody2D.velocity = new Vector2(0f, ownerUnit.unitData.rigidBody2D.velocity.y);
            ownerUnit.unitData.airControl.SetMomentum(0f);
        }


        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.rigidBody2D.velocity.y <= _maxFallVelocity)
            {
                ownerUnit.unitData.rigidBody2D.velocity = new Vector2(ownerUnit.unitData.rigidBody2D.velocity.x, _maxFallVelocity);
            }

            if (fixedUpdateCount >= 1)
            {
                //not touching wall
                List<Ground> sideTouchingGrounds = ownerUnit.unitData.collisionStays.GetSideTouchingGrounds();

                if (sideTouchingGrounds.Count < 2)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(ownerUnit));
                }

                //hit ground
                List<Ground> groundsEnter = ownerUnit.unitData.collisionEnters.GetTouchingGrounds(CollisionType.BOTTOM);

                if (groundsEnter.Count > 0)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                }

                List<Ground> groundsStay = ownerUnit.unitData.collisionStays.GetTouchingGrounds(CollisionType.BOTTOM);

                if (groundsStay.Count > 0)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                }

                //wall jump
                if (ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.JUMP))
                {
                    if (ownerUnit.unitData.facingRight)
                    {
                        ownerUnit.unitData.airControl.SetMomentum(GameInitializer.current.fighterDataSO.WallJumpHorizontalMomentum * -1f);
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Up(ownerUnit, GameInitializer.current.fighterDataSO.WallJumpForce));
                    }
                    else
                    {
                        ownerUnit.unitData.airControl.SetMomentum(GameInitializer.current.fighterDataSO.WallJumpHorizontalMomentum);
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Up(ownerUnit, GameInitializer.current.fighterDataSO.WallJumpForce));
                    }
                }
            }
        }
    }
}