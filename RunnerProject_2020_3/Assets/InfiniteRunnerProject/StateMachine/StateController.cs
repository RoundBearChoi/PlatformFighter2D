using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StateController : IStateController
    {
        public State currentState = null;

        private UnitData _unitData = null;
        private List<SpriteAnimation> _listSpriteAnimations = null;

        public StateController(State newState, UnitData unitData, List<SpriteAnimation> listSpriteAnimations)
        {
            _unitData = unitData;
            _listSpriteAnimations = listSpriteAnimations;
            SetNewState(newState);
        }

        public void UpdateState()
        {
            currentState.Update();
            currentState.updateCount++;
        }

        public void TransitionToNextState()
        {
            if (_unitData.listNextStates.Count > 0)
            {
                if (_listSpriteAnimations != null)
                {
                    foreach (SpriteAnimation spr in _listSpriteAnimations)
                    {
                        spr.Reset();
                    }
                }

                SetNewState(_unitData.listNextStates[_unitData.listNextStates.Count - 1]);
                _unitData.listNextStates.Clear();
            }
        }

        public void SetNewState(State newState)
        {
            currentState = newState;
            currentState.updateCount = 0;
            currentState.OnEnter();
        }
    }
}