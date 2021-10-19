using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UnitState
    {
        public uint fixedUpdateCount = 0;
        public bool disallowTransitionQueue = false;

        protected Unit _ownerUnit = null;
        protected bool noHitStopAllowed = false;
        protected List<StateComponent> _listStateComponents = new List<StateComponent>();
        protected List<SpriteType> _listMatchingSpriteTypes = new List<SpriteType>();

        public bool NO_HITSTOP_ALLOWED
        {
            get
            {
                return noHitStopAllowed;
            }
        }

        public Unit OWNER_UNIT
        {
            get
            {
                return _ownerUnit;
            }
        }

        public void SetOwnerUnit(Unit ownerUnit)
        {
            _ownerUnit = ownerUnit;
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

        public virtual void FixedUpdateComponents()
        {
            foreach (StateComponent component in _listStateComponents)
            {
                component.OnFixedUpdate();
            }
        }

        public virtual bool IsMatching(SpriteType spriteType)
        {
            foreach(SpriteType s in _listMatchingSpriteTypes)
            {
                if (s == spriteType)
                {
                    return true;
                }
            }

            return false;
        }
    }
}