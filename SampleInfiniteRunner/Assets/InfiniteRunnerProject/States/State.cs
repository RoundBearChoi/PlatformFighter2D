using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class State
    {
        public State nextState = null;

        public virtual void OnEnter()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Update(UserInput userInput, GameElement gameElement)
        {

        }
    }
}