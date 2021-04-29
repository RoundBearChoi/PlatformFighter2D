using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class State
    {
        public abstract void Update();
        protected State nextState = null;
    }
}