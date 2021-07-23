using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUpdater : BaseUpdater
    {
        public DefaultUpdater(Unit ownerUnit)
        {
            _unit = ownerUnit;
        }

        public override void CustomUpdate()
        {
            _unit.unitData.spriteAnimations.OnUpdate();

            _unit.iStateController.OnUpdate();

            //only make transition in the update, not in fixedupdate (avoid transitioning multiple times in between frames)
            _unit.iStateController.TransitionToNextState();
        }

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

                _unit.unitData.spriteAnimations.OnFixedUpdate();
                _unit.iStateController.OnFixedUpdate();
            }
            else
            {
                //cancel hitstop when taking damage (wincing)
                if (_unit.iStateController.GetCurrentState().NO_HITSTOP_ALLOWED)
                {
                    _totalHitStopFrames = 0;
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
        }

        public override void CustomLateUpdate()
        {
            _unit.iStateController.OnLateUpdate();
        }
    }
}