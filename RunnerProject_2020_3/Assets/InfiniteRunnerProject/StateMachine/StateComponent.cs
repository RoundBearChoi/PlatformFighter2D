using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class StateComponent
    {
        protected State _state = null;

        public abstract void Update();
    }
}