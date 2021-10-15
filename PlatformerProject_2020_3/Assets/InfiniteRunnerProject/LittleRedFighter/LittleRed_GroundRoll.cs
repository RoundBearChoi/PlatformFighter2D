using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_GroundRoll : UnitState
    {
        public LittleRed_GroundRoll(Unit unit)
        {
            disallowTransitionQueue = true;

            ownerUnit = unit;

            //_listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(ownerUnit, BaseInitializer.current.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new UpdateAirMovementOnMomentum(ownerUnit));

            //_listStateComponents.Add(new CancelJumpForceOnNonPress(ownerUnit, 0));
            //_listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, BaseInitializer.current.fighterDataSO.AttackASlowDownPercentage));

            _listStateComponents.Add(new TriggerMarioStomp(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_GROUND_ROLL);
        }

        public override void OnFixedUpdate()
        {
            float speed = 0f;

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 2)
            {
                speed = BaseInitializer.current.fighterDataSO.DefaultRunSpeed * 1.5f;

                if (!ownerUnit.unitData.facingRight)
                {
                    speed *= -1f;
                }

                ownerUnit.unitData.rigidBody2D.velocity = new Vector2(speed, ownerUnit.unitData.rigidBody2D.velocity.y);
            }
            else if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 6)
            {
                speed = BaseInitializer.current.fighterDataSO.DefaultRunSpeed * 0.8f;

                if (!ownerUnit.unitData.facingRight)
                {
                    speed *= -1f;
                }

                ownerUnit.unitData.rigidBody2D.velocity = new Vector2(speed, ownerUnit.unitData.rigidBody2D.velocity.y);
            }
            else if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 14)
            {
                speed = Mathf.Lerp(ownerUnit.unitData.rigidBody2D.velocity.x, 0f, 0.1f);
                ownerUnit.unitData.rigidBody2D.velocity = new Vector2(speed, ownerUnit.unitData.rigidBody2D.velocity.y);
            }
            else
            {
                ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
            }

            FixedUpdateComponents();
        }
    }
}