using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface IHandleMessage
    {
        public abstract bool Handle();
    }
}