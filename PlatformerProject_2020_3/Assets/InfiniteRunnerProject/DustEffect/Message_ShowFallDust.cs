using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_ShowFallDust : BaseMessage
    {
        Vector3 _position;

        public Message_ShowFallDust(Vector3 position)
        {
            float bottomY = BaseInitializer.current.GetStage().cameraScript.cameraEdges.GetEdge(1).y;
            _position = new Vector3(position.x, bottomY, position.z);

            mMessageType = MessageType.SHOW_FALL_DUST;
        }

        public override void Register()
        {
            BaseInitializer.current.GetStage().units.unitsMessageHandler.Register(this);
        }

        public override Vector3 GetVector3Message()
        {
            return _position;
        }
    }
}