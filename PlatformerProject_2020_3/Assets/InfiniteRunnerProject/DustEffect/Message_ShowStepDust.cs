using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_ShowStepDust : BaseMessage
    {
        bool _faceRightSide = true;
        uint _spriteInterval = 1;
        Vector3 _position = Vector3.zero;
        Vector2 _scaleMultiplier = new Vector2(1f, 1f);

        public Message_ShowStepDust(bool faceRightSide, Vector3 position, Vector2 scaleMultiplier, uint spriteInterval)
        {
            _faceRightSide = faceRightSide;
            _position = position;
            _scaleMultiplier = scaleMultiplier;
            _spriteInterval = spriteInterval;
            mMessageType = MessageType.SHOW_STEP_DUST;
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

        public override uint GetUnsignedIntMessage()
        {
            return _spriteInterval;
        }
    }
}