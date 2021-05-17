using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UnitCreator
    {
        public virtual Unit GetUnit()
        {
            return null;
        }
    }
}