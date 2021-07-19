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
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsOnFlatGround())
            {
                _unit.unitData.rigidBody2D.velocity = Vector2.Lerp(_unit.unitData.rigidBody2D.velocity, Vector2.zero, 0.03f);
            }

            List<Unit> listUnits = _unit.unitData.collisionStays.GetTouchingUnits();

            foreach(Unit unit in listUnits)
            {
                if (unit.unitType == UnitType.RUNNER)
                {
                    if (unit.unitData.hp > 0)
                    {
                        _unit.unitData.listNextStates.Add(new Golem_Attack(_unit));
                        break;
                    }
                }
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}