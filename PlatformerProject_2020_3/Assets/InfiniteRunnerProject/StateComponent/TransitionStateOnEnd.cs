using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TransitionStateOnEnd : StateComponent
    {
        UnitState _nextState;

        public TransitionStateOnEnd(Unit unit, UnitState nextState)
        {
            _unit = unit;
            _nextState = nextState;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                {
                    _unit.unitData.listNextStates.Add(_nextState);
                }
            }
        }
    }
}