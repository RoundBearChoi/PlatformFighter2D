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
        protected List<SpriteType> _listMatchingSpriteTypes = new List<SpriteType>();

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
    }
}