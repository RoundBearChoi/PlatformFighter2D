using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUnitUpdater : BaseUpdater
    {
        private Unit _unit = null;
        private UserInput _userInput = null;

        public DefaultUnitUpdater(Unit ownerUnit)
        {
            _unit = ownerUnit;
            _userInput = GameInitializer.current.GetStage().USER_INPUT;
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
                    //gotta fix
                    if (_userInput.commands.ContainsPress(CommandType.ATTACK_A))
                    {
                        //_unit.iStateController.GetCurrentState().AddButtonQueue(UserInput.mouse.leftButton);
                    }

                    if (_userInput.commands.ContainsPress(CommandType.ATTACK_B))
                    {
                        //_unit.iStateController.GetCurrentState().AddButtonQueue(UserInput.mouse.rightButton);
                    }

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