using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ShowSmashDustMessage : BaseMessage
    {
        bool _faceRightSide = true;
        Vector3 _position;

        public ShowSmashDustMessage(bool faceRightSide, Vector3 position)
        {
            _faceRightSide = faceRightSide;
            _position = position;
            mMessageType = MessageType.SHOW_SMASH_DUST;
        }

        public override void Register()
        {
            BaseInitializer.current.GetStage().units.unitsMessageHandler.Register(this);
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