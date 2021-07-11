using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUpdater : BaseUpdater
    {
        public override void CustomFixedUpdate()
        {
            if (_totalHitStopFrames == 0)
            {
                if (_unit.unitData.rigidBody2D != null)
                {
                    if (_unit.unitData.rigidBody2D.IsSleeping())
                    {
                        _unit.unitData.rigidBody2D.WakeUp();
                    }
                }

                _unit.iStateController.TransitionToNextState();
                _unit.iStateController.OnFixedUpdate();
                _unit.unitData.spriteAnimations.OnFixedUpdate();
            }
            else
            {
                if (_unit.unitData.rigidBody2D != null)
                {
                    _unit.unitData.rigidBody2D.Sleep();
                }

                _totalHitStopFrames--;
            }
        }

        public override void CustomLateUpdate()
        {
            _unit.iStateController.OnLateUpdate();
        }
    }
}