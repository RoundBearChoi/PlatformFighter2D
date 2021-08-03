using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Attack_A_Dash : UnitState
    {
        public Runner_Attack_A_Dash(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new CreateRenderTrail(unit, 1, unit.unitData.facingRight));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_ATTACK_A_DASH);
        }

        public override void OnFixedUpdate()
        {
            ownerUnit.unitData.rigidBody2D.mass = 0.001f;

            FixedUpdateComponents();

            float force = BaseInitializer.current.runnerDataSO.DashForcePerFixedUpdate;

            if (!ownerUnit.unitData.facingRight)
            {
                force *= -1f;
            }

            if (fixedUpdateCount <= BaseInitializer.current.runnerDataSO.DashFixedUpdateCount)
            {
                ownerUnit.unitData.rigidBody2D.velocity = new Vector2(force, 0f);
            }
            else
            {
                ownerUnit.unitData.rigidBody2D.velocity = Vector2.zero;
                ownerUnit.unitData.rigidBody2D.mass = 1f;
                ownerUnit.unitData.listNextStates.Add(new Runner_Attack_A(ownerUnit));
            }
        }
    }
}