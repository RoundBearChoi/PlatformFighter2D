using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class MultiplayerServerStageTransition : IStageTransition
    {
        private BaseInitializer _gameInitializer = null;

        public MultiplayerServerStageTransition(BaseInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public BaseStage MakeTransition()
        {
            ResourceLoader.LoadHostGameStage();

            BaseStage serverStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.MULTIPLAYER_SERVER_STAGE)) as BaseStage;

            serverStage.SetInitializer(_gameInitializer);
            serverStage.transform.parent = _gameInitializer.transform;
            serverStage.transform.localPosition = new Vector3(0f, 0f, 0f);
            serverStage.transform.localRotation = Quaternion.identity;

            return serverStage;
        }
    }
}