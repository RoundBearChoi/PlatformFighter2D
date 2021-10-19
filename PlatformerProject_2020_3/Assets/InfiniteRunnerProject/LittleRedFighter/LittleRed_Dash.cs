using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Dash : UnitState
    {
        public LittleRed_Dash()
        {
            disallowTransitionQueue = true;

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_DASH);
        }

        public override void OnEnter()
        {
            if (!ownerUnit.isDummy)
            {
                _listStateComponents.Add(new CreateRenderTrail(this, 1, ownerUnit.unitData.facingRight));
            }

            float initialMomentum = ownerUnit.unitData.airControl.HORIZONTAL_MOMENTUM * 0.5f;
            ownerUnit.unitData.airControl.SetMomentum(initialMomentum);

            ownerUnit.unitData.rigidBody2D.mass = 0.001f;
            ownerUnit.unitData.airControl.DashTriggered = true;

            if (!ownerUnit.isDummy)
            {
                BaseMessage showDashDust = new Message_ShowDashDust(ownerUnit.unitData.facingRight, ownerUnit.transform.position);
                showDashDust.Register();
            }
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            float force = BaseInitializer.CURRENT.fighterDataSO.DashForce;

            if (!ownerUnit.unitData.facingRight)
            {
                force *= -1f;
            }

            if (fixedUpdateCount <= BaseInitializer.CURRENT.fighterDataSO.DashFixedUpdates)
            {
                ownerUnit.unitData.rigidBody2D.velocity = new Vector2(force, 0f);
            }
            else
            {
                ownerUnit.unitData.rigidBody2D.velocity = Vector2.zero;
                ownerUnit.unitData.rigidBody2D.mass = 1f;

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
}