using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StageTransitioner
    {
        private List<BaseStage> _listNextStages = new List<BaseStage>();
        private BaseMessageHandler _messageHandler = null;

        public StageTransitioner()
        {
            _messageHandler = new StageTransitionerMessageHandler();
            Message_ConnectedToServer.stageTransitionerMessageHandler = _messageHandler;
        }

        public void AddNextStage(BaseStage stage)
        {
            _listNextStages.Add(stage);
        }

        public void Update()
        {
            if (_listNextStages.Count > 0)
            {
                BaseStage currentStage = BaseInitializer.CURRENT.STAGE;

                if (currentStage != null)
                {
                    currentStage.OnExit();
                    GameObject.Destroy(currentStage.gameObject);
                }

                BaseStage newStage = _listNextStages[0];

                BaseInitializer.CURRENT.SetStage(newStage);
                newStage.Init();
            }

            _listNextStages.Clear();

            _messageHandler.HandleMessages();
            _messageHandler.ClearMessages();
        }
    }
}