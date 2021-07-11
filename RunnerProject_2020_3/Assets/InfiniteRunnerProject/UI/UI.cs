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
        private Canvas _canvas = null;
        private List<UIBlock> _listUIBlocks = new List<UIBlock>();
        private UserInput _userInput = null;

        public List<BaseMessage> listMessages = new List<BaseMessage>();
        public Text text_fixedUpdate = null;
        public Text text_FPS = null;

        public static UI currentUI = null;

        private void Start()
        {
            _canvas = this.gameObject.GetComponentInChildren<Canvas>();

            DefaultUIBlock defaultUIBlock = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.DEFAULT_UI_BLOCK), _canvas.transform) as DefaultUIBlock;
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

            foreach(BaseMessage message in listMessages)
            {
                ProcessMessage(message);
            }

            listMessages.Clear();
        }

        public void ProcessMessage(BaseMessage message)
        {
            if (message.MESSAGE_TYPE == MessageType.RUNNER_IS_DEAD)
            {
                Debugger.Log("runner death message received by ui");
                RunnerDeathNotification notification = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.RUNNER_DEATH_NOTIFICATION), _canvas.transform) as RunnerDeathNotification;
                notification.SetUserInput(_userInput);
                _listUIBlocks.Add(notification);
            }
        }
    }
}