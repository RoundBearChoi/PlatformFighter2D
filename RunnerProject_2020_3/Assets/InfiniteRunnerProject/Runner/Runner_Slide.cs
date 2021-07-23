using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Slide : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Slide(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new UpdateCollider2DSize(ownerUnit, new Vector2(0.8f, 2f)));
            _listStateComponents.Add(new LerpRunSpeedOnFlatGround(ownerUnit, 0.1f, 0.035f));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (fixedUpdateCount > 20)
            {
                if (ownerUnit.unitData.rigidBody2D.velocity.x < 1.25f)
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_Slide_GetUp(ownerUnit));
                }
            }
        }
    }
}