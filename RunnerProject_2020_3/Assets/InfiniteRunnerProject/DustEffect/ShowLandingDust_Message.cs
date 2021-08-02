using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ShowLandingDust_Message : BaseMessage
    {
        bool _faceRightSide = true;
        Vector3 _position;
        Vector2 _scaleMultiplier;

        public ShowLandingDust_Message(bool faceRightSide, Vector3 position, Vector2 scaleMultiplier)
        {
            _faceRightSide = faceRightSide;
            _position = position;
            _scaleMultiplier = scaleMultiplier;
            mMessageType = MessageType.SHOW_LANDING_DUST;
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

        public override Vector2 GetVector2Message()
        {
            return _scaleMultiplier;
        }
    }
}