using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseUpdater
    {
        protected Unit _unit = null;

        public virtual void SetOwnerUnit(Unit unit)
        {
            _unit = unit;
        }

        public abstract void CustomFixedUpdate();
        public abstract void CustomLateUpdate();
    }
}