using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death : UnitState
    {
        public Runner_Death(Unit unit)
        {
            _ownerUnit = unit;
            noHitStopAllowed = true;

            _listStateComponents.Add(new SlowDownToZeroOnFlatGround(this, 0.05f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_DEATH);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}