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
            _maxFallVelocity = BaseInitializer.CURRENT.fighterDataSO.MaxWallSlideFallSpeed;

            _listStateComponents.Add(new TriggerDashOnWallSlide(ownerUnit));
            _listStateComponents.Add(new TriggerWallSlideDust(ownerUnit));
            _listStateComponents.Add(new TriggerWallJump(ownerUnit));
            _listStateComponents.Add(new TriggerMarioStomp(ownerUnit));

            ownerUnit.unitData.airControl.DashTriggered = false;

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
                List<CollisionData> sideTouchingGrounds = ownerUnit.unitData.collisionStays.GetSideTouchingGrounds();

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

                //fall off
                if (ownerUnit.unitData.facingRight)
                {
                    if (ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) && ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
                    {
                        ownerUnit.unitData.airControl.SetMomentum(BaseInitializer.CURRENT.fighterDataSO.WallFallHorizontalMomentum * -1f);
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(ownerUnit));
                    }
                }
                else
                {
                    if (ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) && ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
                    {
                        ownerUnit.unitData.airControl.SetMomentum(BaseInitializer.CURRENT.fighterDataSO.WallFallHorizontalMomentum);
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(ownerUnit));
                    }
                }
            }
        }
    }
}