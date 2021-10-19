using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_WallSlide : UnitState
    {
        private float _maxFallVelocity = 0f;

        public LittleRed_WallSlide()
        {
            _maxFallVelocity = BaseInitializer.CURRENT.fighterDataSO.MaxWallSlideFallSpeed;

            _listStateComponents.Add(new TriggerDashOnWallSlide(this));
            _listStateComponents.Add(new TriggerWallSlideDust(this));
            _listStateComponents.Add(new TriggerWallJump(this));
            _listStateComponents.Add(new TriggerMarioStomp(this));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_WALLSLIDE);
        }

        public override void OnEnter()
        {
            _ownerUnit.unitData.airControl.DashTriggered = false;
            _ownerUnit.unitData.rigidBody2D.velocity = new Vector2(0f, _ownerUnit.unitData.rigidBody2D.velocity.y);
            _ownerUnit.unitData.airControl.SetMomentum(0f);
        }


        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.unitData.rigidBody2D.velocity.y <= _maxFallVelocity)
            {
                _ownerUnit.unitData.rigidBody2D.velocity = new Vector2(_ownerUnit.unitData.rigidBody2D.velocity.x, _maxFallVelocity);
            }

            if (fixedUpdateCount >= 1)
            {
                //not touching wall
                List<CollisionData> sideTouchingGrounds = _ownerUnit.unitData.collisionStays.GetSideTouchingGrounds();

                if (sideTouchingGrounds.Count < 2)
                {
                    _ownerUnit.listNextStates.Add(new LittleRed_Jump_Fall());
                }

                //hit ground
                List<Ground> groundsEnter = _ownerUnit.unitData.collisionEnters.GetTouchingGrounds(CollisionType.BOTTOM);

                if (groundsEnter.Count > 0)
                {
                    _ownerUnit.listNextStates.Add(new LittleRed_Idle());
                }

                List<Ground> groundsStay = _ownerUnit.unitData.collisionStays.GetTouchingGrounds(CollisionType.BOTTOM);

                if (groundsStay.Count > 0)
                {
                    _ownerUnit.listNextStates.Add(new LittleRed_Idle());
                }

                //fall off
                if (_ownerUnit.facingRight)
                {
                    if (_ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) && _ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
                    {
                        _ownerUnit.unitData.airControl.SetMomentum(BaseInitializer.CURRENT.fighterDataSO.WallFallHorizontalMomentum * -1f);
                        _ownerUnit.listNextStates.Add(new LittleRed_Jump_Fall());
                    }
                }
                else
                {
                    if (_ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) && _ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
                    {
                        _ownerUnit.unitData.airControl.SetMomentum(BaseInitializer.CURRENT.fighterDataSO.WallFallHorizontalMomentum);
                        _ownerUnit.listNextStates.Add(new LittleRed_Jump_Fall());
                    }
                }
            }
        }
    }
}