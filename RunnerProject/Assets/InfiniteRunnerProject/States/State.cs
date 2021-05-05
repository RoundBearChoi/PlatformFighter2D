using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class State
    {
        public State nextState = null;

        protected UnitData unitData = null;
        protected UserInput userInput = null;

        public virtual void OnEnter()
        {

        }

        public virtual void Update()
        {

        }
    }
}