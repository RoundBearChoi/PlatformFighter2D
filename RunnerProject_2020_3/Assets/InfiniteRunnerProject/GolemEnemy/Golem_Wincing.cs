using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Wincing : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Golem_Wincing(Unit unit)
        {
            ownerUnit = unit;
            noHitStopAllowed = true;

            _listStateComponents.Add(new InitialPushBack(ownerUnit, new Vector2(3.5f, 2.75f)));
            _listStateComponents.Add(new InitialTextGUIMaterial(ownerUnit, 8));
            _listStateComponents.Add(new SlowDownToZeroOnFlatGround(ownerUnit, 0.1f));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
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