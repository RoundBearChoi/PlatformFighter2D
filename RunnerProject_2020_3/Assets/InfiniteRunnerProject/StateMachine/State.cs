using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class State
    {
        static Hash128 defaultHash;

        public uint updateCount = 0;

        protected Unit _unit = null;
        protected List<StateComponent> _listStateComponents = new List<StateComponent>();

        public abstract void SetHashString();

        public virtual Hash128 GetAnimationHash()
        {
            defaultHash = Hash128.Compute("defaultHash");
            return defaultHash;
        }

        public State()
        {
            SetHashString();
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

        }

        public virtual void UpdateComponents()
        {
            foreach (StateComponent component in _listStateComponents)
            {
                component.Update();
            }
        }
    }
}