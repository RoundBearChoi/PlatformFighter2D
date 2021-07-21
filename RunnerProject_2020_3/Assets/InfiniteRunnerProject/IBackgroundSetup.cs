using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface IBackgroundSetup
    {
        public abstract void InstantiateBaseLayer();
        public abstract Unit InstantiateAdditionalBackgroundUnit<T>();
        public abstract void AddAdditionalBackground<T>() where T : UnitState;
    }
}