using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseMessage
    {
        protected MessageType mMessageType = MessageType.NONE;

        public abstract void Register();

        public MessageType MESSAGE_TYPE
        {
            get
            {
                return mMessageType;
            }
        }
                
        public virtual uint GetUnsignedIntMessage()
        {
            return 0;
        }

        public virtual float GetFloatMessage()
        {
            return 0f;
        }

        public virtual bool GetBoolMessage()
        {
            return false;
        }
    }
}