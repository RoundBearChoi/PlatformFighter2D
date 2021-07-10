using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseMessage
    {
        public abstract void Register();

        public virtual string GetStringMessage()
        {
            return string.Empty;
        }
        
        public virtual uint GetUnsignedIntMessage()
        {
            return 0;
        }

        public virtual float GetFloatMessage()
        {
            return 0f;
        }
    }
}