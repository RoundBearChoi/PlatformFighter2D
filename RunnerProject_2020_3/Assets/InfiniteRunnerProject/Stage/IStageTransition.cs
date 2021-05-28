using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface IStageTransition
    {
        public abstract Stage MakeTransition();
    }
}