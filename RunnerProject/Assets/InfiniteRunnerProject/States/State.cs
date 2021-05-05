using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class State
    {
        public State nextState = null;

        protected GameElementData elementData = null;
        protected UserInput userInput = null;

        public virtual void OnEnter()
        {

        }

        public virtual void Update()
        {

        }
    }
}