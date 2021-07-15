using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseMessageHandler
    {
        protected List<BaseMessage> _listMessages = new List<BaseMessage>();

        public abstract void HandleMessages();

        public virtual void Register(BaseMessage message)
        {
            _listMessages.Add(message);
        }

        public virtual void ClearMessages()
        {
            _listMessages.Clear();
        }
    }
}