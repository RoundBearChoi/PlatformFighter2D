using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UnitState
    {
        public uint fixedUpdateCount = 0;
        
        public Unit ownerUnit = null;
        protected List<StateComponent> _listStateComponents = new List<StateComponent>();
        
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

        public abstract SpriteAnimationSpec GetSpriteAnimationSpec();
    }
}