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

        public virtual int GetIntMessage()
        {
            return 0;
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

        public virtual Vector3 GetVector3Message()
        {
            return Vector3.zero;
        }

        public virtual UnitType GetUnitTypeMessage()
        {
            return UnitType.NONE;
        }
    }
}