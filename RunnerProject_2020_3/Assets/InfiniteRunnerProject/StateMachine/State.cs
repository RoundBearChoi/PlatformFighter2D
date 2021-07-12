using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class State
    {
        public uint updateCount = 0;
        
        protected Unit _unit = null;
        protected List<StateComponent> _listStateComponents = new List<StateComponent>();

        public virtual void OnEnter()
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

        public virtual void FixedUpdateComponents()
        {
            foreach (StateComponent component in _listStateComponents)
            {
                component.OnFixedUpdate();
            }
        }

        public abstract SpriteAnimationSpec GetSpriteAnimationSpec();
    }
}