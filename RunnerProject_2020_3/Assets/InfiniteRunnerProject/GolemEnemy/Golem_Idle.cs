using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Idle : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Golem_Idle(Unit unit)
        {
            ownerUnit = unit;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            if (ownerUnit.unitData.collisionStays.IsOnFlatGround())
            {
                ownerUnit.unitData.rigidBody2D.velocity = Vector2.Lerp(ownerUnit.unitData.rigidBody2D.velocity, Vector2.zero, 0.03f);
            }

            List<Unit> listUnits = ownerUnit.unitData.collisionStays.GetTouchingUnits();

            foreach(Unit unit in listUnits)
            {
                if (unit.unitType == UnitType.RUNNER)
                {
                    if (unit.unitData.hp > 0)
                    {
                        ownerUnit.unitData.listNextStates.Add(new Golem_Attack(ownerUnit));
                        break;
                    }
                }
            }
        }
    }
}