using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class UI : MonoBehaviour
    {
        private FixedUpdateCounter fixedUpdateCounter = null;
        private UpdateCounter updateCounter = null;
        private List<IMessage> _listMessages = new List<IMessage>();

        public Text text_fixedUpdate = null;
        public Text text_FPS = null;

        public void SetCounters(FixedUpdateCounter _fixedUpdateCounter, UpdateCounter _updateCounter)
        {
            fixedUpdateCounter = _fixedUpdateCounter;
            updateCounter = _updateCounter;
        }

        public void OnUpdate()
        {
            text_fixedUpdate.text = "FixedUpdate count: " + fixedUpdateCounter.GetCount();
            text_FPS.text = "FPS: " + updateCounter.GetCount();
        }

        public void OnFixedUpdate()
        {
            foreach(IMessage message in _listMessages)
            {
                if (message.GetStringMessage().Equals("runner is dead"))
                {
                    Debugger.Log("ui knows runner is dead");
                }
            }

            _listMessages.Clear();
        }

        public void AddMessage(IMessage message)
        {
            _listMessages.Add(message);
        }
    }
}