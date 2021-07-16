using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ParryEffectMessage : BaseMessage
    {
        Vector3 _position;

        public ParryEffectMessage(Vector3 position)
        {
            _position = position;
            mMessageType = MessageType.SHOW_PARRY_EFFECT;
        }

        public override void Register()
        {
            Stage.currentStage.units.unitsMessageHandler.Register(this);
        }

        public override Vector3 GetVector3Message()
        {
            return _position;
        }
    }
}