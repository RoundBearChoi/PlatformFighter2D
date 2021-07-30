using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Wincing : UnitState
    {
        public Golem_Wincing(Unit unit, Vector2 pushForce, Unit attacker)
        {
            ownerUnit = unit;
            noHitStopAllowed = true;

            _listStateComponents.Add(new InitialPushBack(ownerUnit, pushForce, attacker));
            _listStateComponents.Add(new InitialTextGUIMaterial(ownerUnit, 8));
            _listStateComponents.Add(new SlowDownToZeroOnFlatGround(ownerUnit, 0.1f));

            _listMatchingSpriteTypes.Add(SpriteType.GOLEM_WINCING);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (fixedUpdateCount >= 20)
            {
                ownerUnit.unitData.listNextStates.Add(new Golem_Idle(ownerUnit));
            }
        }
    }
}