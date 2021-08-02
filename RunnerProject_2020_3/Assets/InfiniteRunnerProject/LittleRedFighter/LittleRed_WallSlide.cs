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

            //show wallslide dust
            if (fixedUpdateCount != 0 && fixedUpdateCount % ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().animationSpec.spriteInterval == 0)
            {
                if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 1 ||
                    ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 2)
                {
                    float x = 0f;
                    float y = 0f;

                    List<CollisionData> sideCollisions = ownerUnit.unitData.collisionStays.GetSideCollisionData();

                    foreach(CollisionData data in sideCollisions)
                    {
                        if (data.collidingObject.GetComponent<Ground>() != null)
                        {
                            x = data.contactPoint.point.x;
                            break;
                        }
                    }

                    y = ownerUnit.transform.position.y + 1.5f;

                    Vector3 dustPosition = new Vector3(x, y, GameInitializer.current.fighterDataSO.DustEffects_z);

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
                    float initialMomentum = GameInitializer.current.fighterDataSO.WallJumpHorizontalMomentum;

                    if (ownerUnit.unitData.facingRight)
                    {
                        initialMomentum *= -1f;
                    }

                    //show walljump dust
                    List<CollisionData> sideCollisions = ownerUnit.unitData.collisionStays.GetSideCollisionData();

                    float x = 0f;
                    float y = 0f;

                    foreach (CollisionData data in sideCollisions)
                    {
                        if (data.collidingObject.GetComponent<Ground>() != null)
                        {
                            x = data.contactPoint.point.x;
                            break;
                        }
                    }

                    y = ownerUnit.transform.position.y + 0.7f;

                    Vector3 dustPosition = new Vector3(x, y, GameInitializer.current.fighterDataSO.DustEffects_z);

                    BaseMessage showWallJumpDust = new ShowWallJumpDust_Message(ownerUnit.unitData.facingRight, dustPosition, new Vector2(1f, 1f));
                    showWallJumpDust.Register();

                    ownerUnit.unitData.airControl.SetMomentum(initialMomentum);
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Up(ownerUnit, GameInitializer.current.fighterDataSO.WallJumpForce));
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