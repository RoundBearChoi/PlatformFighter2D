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

            //show dust
            if (fixedUpdateCount != 0 && fixedUpdateCount % ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().animationSpec.spriteInterval == 0)
            {
                if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 1 ||
                    ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 2)
                {
                    float x = 0.6f;
                    float y = 1.5f;

                    Vector3 dustPosition = Vector3.zero;

                    if (ownerUnit.unitData.facingRight)
                    {
                        dustPosition = ownerUnit.transform.position + new Vector3(x, y, 0f);
                    }
                    else
                    {
                        dustPosition = ownerUnit.transform.position + new Vector3(-x, y, 0f);
                    }

                    BaseMessage showWallSlideDust = new ShowWallSlideDust_Message(ownerUnit.unitData.facingRight, dustPosition, new Vector2(1f, 1f));
                    showWallSlideDust.Register();
                }
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

                //fall off
                if (ownerUnit.unitData.facingRight)
                {
                    if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT) && ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_DOWN))
                    {
                        ownerUnit.unitData.airControl.SetMomentum(GameInitializer.current.fighterDataSO.WallFallHorizontalMomentum * -1f);
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(ownerUnit));
                    }
                }
                else
                {
                    if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_RIGHT) && ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_DOWN))
                    {
                        ownerUnit.unitData.airControl.SetMomentum(GameInitializer.current.fighterDataSO.WallFallHorizontalMomentum);
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(ownerUnit));
                    }
                }
            }
        }
    }
}