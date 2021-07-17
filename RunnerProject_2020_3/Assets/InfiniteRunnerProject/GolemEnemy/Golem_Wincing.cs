using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Wincing : State
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Golem_Wincing(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new InitialPushBack(_unit, new Vector2(3.5f, 2.75f)));
            _listStateComponents.Add(new InitialTextGUIMaterial(_unit, 8));
            _listStateComponents.Add(new SlowDownToZeroOnFlatGround(_unit, 0.1f));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (updateCount >= 20)
            {
                _unit.unitData.listNextStates.Add(new Golem_Idle(_unit));
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}