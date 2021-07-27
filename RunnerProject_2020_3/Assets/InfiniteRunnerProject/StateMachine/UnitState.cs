using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UnitState
    {
        public uint fixedUpdateCount = 0;
        
        public Unit ownerUnit = null;

        protected bool noHitStopAllowed = false;
        protected List<StateComponent> _listStateComponents = new List<StateComponent>();
        protected Dictionary<UnityEngine.InputSystem.Controls.ButtonControl, uint> _dicQueuedButtonPresses = new Dictionary<UnityEngine.InputSystem.Controls.ButtonControl, uint>();

        public abstract SpriteAnimationSpec GetSpriteAnimationSpec();

        public bool NO_HITSTOP_ALLOWED
        {
            get
            {
                return noHitStopAllowed;
            }
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual UnitState GetLastestInstantiatedState()
        {
            return null;
        }

        public virtual void UpdateComponents()
        {
            foreach (StateComponent component in _listStateComponents)
            {
                component.OnUpdate();
            }
        }

        public virtual void FixedUpdateComponents()
        {
            foreach (StateComponent component in _listStateComponents)
            {
                component.OnFixedUpdate();
            }
        }

        public void AddButtonQueue(UnityEngine.InputSystem.Controls.ButtonControl button)
        {
            if (_dicQueuedButtonPresses.ContainsKey(button))
            {
                _dicQueuedButtonPresses[button] += 1;
            }
            else
            {
                _dicQueuedButtonPresses.Add(button, 0);
            }
        }

        public bool ButtonIsPressed(UnityEngine.InputSystem.Controls.ButtonControl button)
        {
            if (GameInitializer.current.GetStage().USER_INPUT.ContainsButtonPress(button))
            {
                return true;
            }

            if (_dicQueuedButtonPresses.ContainsKey(button))
            {
                if (_dicQueuedButtonPresses[button] > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}