using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface IBackgroundSetup
    {
        public abstract void InstantiateBaseLayer();
        public abstract void AddAdditionalAdjacentUnit<T>() where T : UnitState;
    }
}