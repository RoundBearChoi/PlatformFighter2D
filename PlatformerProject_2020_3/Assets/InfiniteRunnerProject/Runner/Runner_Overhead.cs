using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Overhead : UnitState
    {
        public Runner_Overhead(Unit unit)
        {
            _ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 3f, 0.05f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_OVERHEAD);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                _ownerUnit.listNextStates.Add(new Runner_NormalRun());
            }
        }
    }
}