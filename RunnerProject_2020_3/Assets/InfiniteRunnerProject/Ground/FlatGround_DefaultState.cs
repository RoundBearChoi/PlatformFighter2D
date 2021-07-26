using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FlatGround_DefaultState : UnitState
    {
        public static FlatGround_DefaultState latest;

        public FlatGround_DefaultState(Unit unit)
        {
            latest = this;
            ownerUnit = unit;

            _listStateComponents.Add(new DeletePassedGround(unit));
            _listStateComponents.Add(new AddFlatGround(this));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return null;
        }

        public override UnitState GetLastestInstantiatedState()
        {
            return latest;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}