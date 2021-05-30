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
        private Canvas _canvas = null;
        private List<UIBlock> _listUIBlocks = new List<UIBlock>();
        private UserInput _userInput = null;

        public Text text_fixedUpdate = null;
        public Text text_FPS = null;

        private void Start()
        {
            _canvas = this.gameObject.GetComponentInChildren<Canvas>();

            DefaultUIBlock defaultUIBlock = Instantiate(ResourceLoader.GetResource(typeof(DefaultUIBlock)) as DefaultUIBlock, _canvas.transform);
            _listUIBlocks.Add(defaultUIBlock);
        }

        public void SetCounters(FixedUpdateCounter _fixedUpdateCounter, UpdateCounter _updateCounter)
        {
            fixedUpdateCounter = _fixedUpdateCounter;
            updateCounter = _updateCounter;
        }

        public void SetInput(UserInput input)
        {
            _userInput = input;
        }

        public void OnUpdate()
        {
            text_fixedUpdate.text = "FixedUpdate count: " + fixedUpdateCounter.GetCount();
            text_FPS.text = "FPS: " + updateCounter.GetCount();
        }

        public void OnFixedUpdate()
        {
            //only update the latest block
            _listUIBlocks[_listUIBlocks.Count - 1].UpdateUIBlock();

            foreach(IMessage message in _listMessages)
            {
                ProcessMessage(message);
            }

            _listMessages.Clear();
        }

        public void AddMessage(IMessage message)
        {
            _listMessages.Add(message);
        }

        public void ProcessMessage(IMessage message)
        {
            if (message.GetStringMessage().Equals("runner is dead"))
            {
                Debugger.Log("ui knows runner is dead");
                RunnerDeathNotification notification = Instantiate(ResourceLoader.GetResource(typeof(RunnerDeathNotification)) as RunnerDeathNotification, _canvas.transform);
                notification.SetUserInput(_userInput);
                _listUIBlocks.Add(notification);
            }
        }
    }
}