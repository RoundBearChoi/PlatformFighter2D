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
            ownerUnit = unit;
            ownerUnit.gameObject.layer = (int)LayerType.GHOSTING_UNIT;
            noHitStopAllowed = true;

            _listStateComponents.Add(new InitialTextGUIMaterial(ownerUnit, 8));

            _listMatchingSpriteTypes.Add(SpriteType.GOLEM_DEATH);
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.collisionStays.IsOnFlatGround())
            {
                ownerUnit.unitData.rigidBody2D.velocity = Vector2.Lerp(ownerUnit.unitData.rigidBody2D.velocity, Vector2.zero, 0.05f);
            }
        }
    }
}