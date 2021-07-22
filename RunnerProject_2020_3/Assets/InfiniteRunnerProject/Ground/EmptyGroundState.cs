using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class EmptyGroundState : UnitState
    {
        public static EmptyGroundState latest;

        public EmptyGroundState(Unit unit)
        {
            latest = this;
            ownerUnit = unit;

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