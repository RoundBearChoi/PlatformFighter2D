using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StateController : IStateController
    {
        public State currentState = null;

        private UnitData _unitData = null;
        private SpriteAnimations _spriteAnimations = null;

        public StateController(State newState, UnitData unitData)
        {
            _unitData = unitData;
            SetNewState(newState);
        }

        public void OnFixedUpdate()
        {
            currentState.OnFixedUpdate();
            currentState.updateCount++;
        }

        public void OnLateUpdate()
        {
            currentState.OnLateUpdate();
        }

        public void TransitionToNextState()
        {
            if (_unitData.listNextStates.Count > 0)
            {
                _spriteAnimations.ResetSpriteIndexes();

                SetNewState(_unitData.listNextStates[_unitData.listNextStates.Count - 1]);
                _unitData.listNextStates.Clear();
            }
        }

        public void SetSpriteAnimations(SpriteAnimations spriteAnimations)
        {
            _spriteAnimations = spriteAnimations;
        }

        public Hash128 GetAnimationHash()
        {
            if (currentState != null)
            {
                return currentState.GetAnimationHash();
            }

            Hash128 none = Hash128.Compute("none");
            return none;
        }

        public void SetNewState(State newState)
        {
            currentState = newState;
            currentState.updateCount = 0;
            currentState.OnEnter();
        }
    }
}