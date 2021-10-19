using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Attack_A_Dash : UnitState
    {
        public Runner_Attack_A_Dash()
        {
            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_ATTACK_A_DASH);
        }

        public override void OnEnter()
        {
            _listStateComponents.Add(new CreateRenderTrail(this, 1, ownerUnit.facingRight));
        }

        public override void OnFixedUpdate()
        {
            ownerUnit.unitData.rigidBody2D.mass = 0.001f;

            FixedUpdateComponents();

            float force = BaseInitializer.CURRENT.runnerDataSO.DashForcePerFixedUpdate;

            if (!ownerUnit.facingRight)
            {
                force *= -1f;
            }

            if (fixedUpdateCount <= BaseInitializer.CURRENT.runnerDataSO.DashFixedUpdateCount)
            {
                ownerUnit.unitData.rigidBody2D.velocity = new Vector2(force, 0f);
            }
            else
            {
                ownerUnit.unitData.rigidBody2D.velocity = Vector2.zero;
                ownerUnit.unitData.rigidBody2D.mass = 1f;
                ownerUnit.listNextStates.Add(new Runner_Attack_A(ownerUnit));
            }
        }
    }
}