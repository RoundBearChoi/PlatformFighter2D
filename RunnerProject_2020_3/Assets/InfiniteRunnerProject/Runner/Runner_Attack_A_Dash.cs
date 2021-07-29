using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Attack_A_Dash : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Attack_A_Dash(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new CreateRenderTrail(unit, 1));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            ownerUnit.unitData.rigidBody2D.mass = 0.001f;

            FixedUpdateComponents();

            float force = GameInitializer.current.runnerDataSO.DashForcePerFixedUpdate;

            if (!ownerUnit.unitData.facingRight)
            {
                force *= -1f;
            }

            if (fixedUpdateCount <= GameInitializer.current.runnerDataSO.DashFixedUpdateCount)
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