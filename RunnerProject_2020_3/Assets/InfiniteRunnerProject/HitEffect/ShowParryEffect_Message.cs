using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ShowParryEffect_Message : BaseMessage
    {
        Vector3 _position;

        public ShowParryEffect_Message(Vector3 position)
        {
            _position = position;
            mMessageType = MessageType.SHOW_PARRY_EFFECT;
        }

        public override void Register()
        {
            GameInitializer.current.STAGE.units.unitsMessageHandler.Register(this);
        }

        public override Vector3 GetVector3Message()
        {
            return _position;
        }
    }
}