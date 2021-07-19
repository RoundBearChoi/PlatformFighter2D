using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_AttackA_Slash : State
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_AttackA_Slash(Unit unit)
        {
            _unit = unit;
            _listStateComponents.Add(new CreateRenderTrail(unit, 3));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            _unit.unitData.rigidBody2D.mass = 0.001f;

            float force = 100f;

            if (!_unit.unitData.facingRight)
            {
                force *= -1f;
            }

            if (updateCount <= 2)
            {
                _unit.unitData.rigidBody2D.velocity = new Vector2(100f, 0f);
            }
            else
            {
                _unit.unitData.rigidBody2D.velocity = Vector2.zero;
                _unit.unitData.rigidBody2D.mass = 1f;
                _unit.unitData.listNextStates.Add(new Runner_AttackA(_unit));
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}