using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ShowJumpDust_Message : BaseMessage
    {
        bool _faceRightSide = true;
        Vector3 _position;

        public ShowJumpDust_Message(bool faceRightSide, Vector3 position)
        {
            _faceRightSide = faceRightSide;
            _position = position;
            mMessageType = MessageType.SHOW_JUMP_DUST;
        }

        public override void Register()
        {
            GameInitializer.current.STAGE.units.unitsMessageHandler.Register(this);
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