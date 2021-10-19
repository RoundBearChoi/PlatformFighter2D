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
            if (!_ownerUnit.isDummy)
            {
                _listStateComponents.Add(new CreateRenderTrail(this, 1, _ownerUnit.facingRight));
            }

            float initialMomentum = _ownerUnit.unitData.airControl.HORIZONTAL_MOMENTUM * 0.5f;
            _ownerUnit.unitData.airControl.SetMomentum(initialMomentum);

            _ownerUnit.unitData.rigidBody2D.mass = 0.001f;
            _ownerUnit.unitData.airControl.DashTriggered = true;

            if (!_ownerUnit.isDummy)
            {
                BaseMessage showDashDust = new Message_ShowDashDust(_ownerUnit.facingRight, _ownerUnit.transform.position);
                showDashDust.Register();
            }
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            float force = BaseInitializer.CURRENT.fighterDataSO.DashForce;

            if (!_ownerUnit.facingRight)
            {
                force *= -1f;
            }

            if (fixedUpdateCount <= BaseInitializer.CURRENT.fighterDataSO.DashFixedUpdates)
            {
                _ownerUnit.unitData.rigidBody2D.velocity = new Vector2(force, 0f);
            }
            else
            {
                _ownerUnit.unitData.rigidBody2D.velocity = Vector2.zero;
                _ownerUnit.unitData.rigidBody2D.mass = 1f;

                if (_ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                {
                    _ownerUnit.listNextStates.Add(new LittleRed_Idle());
                }
                else
                {
                    _ownerUnit.listNextStates.Add(new LittleRed_Jump_Fall());
                }
            }
        }
    }
}