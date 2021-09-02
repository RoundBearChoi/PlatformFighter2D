using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class StateComponent
    {
        protected Unit _unit = null;

        public virtual void OnUpdate()
        {

        }
        public virtual void OnFixedUpdate()
        {

        }
    }
}