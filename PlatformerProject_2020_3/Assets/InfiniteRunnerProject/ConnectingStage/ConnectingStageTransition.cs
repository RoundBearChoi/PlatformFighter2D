using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ConnectingStageTransition : IStageTransition
    {
        private BaseInitializer _gameInitializer = null;

        public ConnectingStageTransition(BaseInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public BaseStage MakeTransition()
        {
            ResourceLoader.LoadHostGameStage();

            BaseStage connectingStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.CONNECTING_STAGE)) as BaseStage;

            connectingStage.SetInitializer(_gameInitializer);
            connectingStage.transform.parent = _gameInitializer.transform;
            connectingStage.transform.localPosition = new Vector3(0f, 0f, 0f);
            connectingStage.transform.localRotation = Quaternion.identity;

            return connectingStage;
        }
    }
}