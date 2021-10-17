using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_ShowParryEffect : BaseMessage
    {
        Vector3 _position;

        public Message_ShowParryEffect(Vector3 position)
        {
            _position = position;
            mMessageType = MessageType.SHOW_PARRY_EFFECT;
        }

        public override void Register()
        {
            BaseInitializer.current.STAGE.units.unitsMessageHandler.Register(this);
        }

        public override Vector3 GetVector3Message()
        {
            return _position;
        }
    }
}