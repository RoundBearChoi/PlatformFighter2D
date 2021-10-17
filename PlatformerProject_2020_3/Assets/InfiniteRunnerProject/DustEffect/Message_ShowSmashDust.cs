using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_ShowSmashDust : BaseMessage
    {
        bool _faceRightSide = true;
        Vector3 _position;

        public Message_ShowSmashDust(bool faceRightSide, Vector3 position)
        {
            _faceRightSide = faceRightSide;
            _position = position;
            mMessageType = MessageType.SHOW_SMASH_DUST;
        }

        public override void Register()
        {
            BaseInitializer.CURRENT.STAGE.units.unitsMessageHandler.Register(this);
        }

        public override bool GetBoolMessage()
        {
            return _faceRightSide;
        }

        public override Vector3 GetVector3Message()
        {
            return _position;
        }
    }
}