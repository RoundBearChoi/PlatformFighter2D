using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUnitUpdater : BaseUpdater
    {
        private Unit _unit = null;
        private Vector2 _previousVelocity = new Vector2();

        public DefaultUnitUpdater(Unit ownerUnit)
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
                    if (_unit.unitData.rigidBody2D.isKinematic)
                    {
                        _unit.unitData.rigidBody2D.velocity = _previousVelocity;

                        Debugger.Log("momentum on wakeup: " + _unit.unitData.airControl.HORIZONTAL_MOMENTUM);
                        Debugger.Log("velocity on wakeup: " + _unit.unitData.rigidBody2D.velocity);

                        _unit.unitData.rigidBody2D.isKinematic = false;
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
                        if (!_unit.unitData.rigidBody2D.isKinematic)
                        {
                            Debugger.Log("momentum on sleep: " + _unit.unitData.airControl.HORIZONTAL_MOMENTUM);
                            Debugger.Log("velocity on sleep: " + _unit.unitData.rigidBody2D.velocity);

                            _previousVelocity = _unit.unitData.rigidBody2D.velocity;
                            _unit.unitData.rigidBody2D.velocity = Vector2.zero;
                            _unit.unitData.rigidBody2D.isKinematic = true;
                        }
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