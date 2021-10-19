using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRedUppercut : UnitState
    {
        private bool initialFaceRight = true;
        private bool _uppercutEffectShown = false;

        public LittleRedUppercut()
        {
            disallowTransitionQueue = true;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, BaseInitializer.CURRENT.fighterDataSO.AttackASlowDownPercentage));
            _listStateComponents.Add(new DelayedJump(this, BaseInitializer.CURRENT.fighterDataSO.VerticalJumpForce * 0.75f, 2));
            _listStateComponents.Add(new UpdateAirMovementOnMomentum(this));
            _listStateComponents.Add(new OverlapBoxCollision(this, BaseInitializer.CURRENT.GetOverlapBoxCollisionData(OverlapBoxDataType.LITTLE_RED_UPPERCUT)));

            _listStateComponents.Add(new TriggerLittleRedAttackA(this, 10));
            _listStateComponents.Add(new TriggerAirDash(this, 10));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_UPPERCUT);
        }

        public override void OnEnter()
        {
            initialFaceRight = ownerUnit.unitData.facingRight;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            SpriteAnimation ani = ownerUnit.unitData.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                float forwardVelocity = 0f;

                if (ani.SPRITE_INDEX >= 2)
                {
                    if (!ownerUnit.isDummy)
                    {
                        if (!_uppercutEffectShown)
                        {
                            _uppercutEffectShown = true;

                            if (ownerUnit.unitType == UnitType.LITTLE_RED_LIGHT)
                            {
                                BaseInitializer.CURRENT.STAGE.InstantiateUnit_ByUnitType(UnitType.UPPERCUT_EFFECT_LIGHT, new UppercutEffect_Light_DefaultState());
                                Unit lightUppercutVFX = Units.instance.GetUnit<UppercutEffect_Light>();
                                lightUppercutVFX.transform.parent = ownerUnit.transform;
                                lightUppercutVFX.transform.position = ownerUnit.transform.position;

                                lightUppercutVFX.unitData.facingRight = ownerUnit.unitData.facingRight;
                            }
                            else if (ownerUnit.unitType == UnitType.LITTLE_RED_DARK)
                            {
                                BaseInitializer.CURRENT.STAGE.InstantiateUnit_ByUnitType(UnitType.UPPERCUT_EFFECT_DARK, new UppercutEffect_Dark_DefaultState());
                                Unit darkUppercutVFX = Units.instance.GetUnit<UppercutEffect_Dark>();
                                darkUppercutVFX.transform.parent = ownerUnit.transform;
                                darkUppercutVFX.transform.position = ownerUnit.transform.position;

                                darkUppercutVFX.unitData.facingRight = ownerUnit.unitData.facingRight;
                            }
                        }
                    }

                    if (ownerUnit.unitData.facingRight)
                    {
                        forwardVelocity = 1f;
                    }
                    else
                    {
                        forwardVelocity = -1f;
                    }
                }
                else if (ani.SPRITE_INDEX >= 6)
                {
                    if (ownerUnit.unitData.facingRight)
                    {
                        forwardVelocity = 0.5f;
                    }
                    else
                    {
                        forwardVelocity = -0.5f;
                    }
                }
                else if (ani.SPRITE_INDEX >= 10)
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
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle());
                    }
                    else
                    {
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall());
                    }
                }
            }
        }

        public override void OnExit()
        {
            if (initialFaceRight)
            {
                ownerUnit.unitData.airControl.SetMomentum(0.001f);
            }
            else
            {
                ownerUnit.unitData.airControl.SetMomentum(-0.001f);
            }
        }
    }
}