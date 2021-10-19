using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TransitionStateOnEnd : StateComponent
    {
        UnitState _nextState;

        public TransitionStateOnEnd(UnitState unitState, UnitState nextState)
        {
            _unitState = unitState;
            _nextState = nextState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                if (UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                {
                    UNIT.listNextStates.Add(_nextState);
                }
            }
        }
    }
}