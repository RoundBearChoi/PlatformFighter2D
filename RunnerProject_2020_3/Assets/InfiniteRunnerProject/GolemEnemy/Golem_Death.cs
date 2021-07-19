using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Death : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Golem_Death(Unit unit)
        {
            _unit = unit;
            _unit.gameObject.layer = (int)LayerType.DEAD_UNIT;

            _listStateComponents.Add(new InitialTextGUIMaterial(_unit, 8));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_unit.unitData.collisionStays.IsOnFlatGround())
            {
                _unit.unitData.rigidBody2D.velocity = Vector2.Lerp(_unit.unitData.rigidBody2D.velocity, Vector2.zero, 0.05f);
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}