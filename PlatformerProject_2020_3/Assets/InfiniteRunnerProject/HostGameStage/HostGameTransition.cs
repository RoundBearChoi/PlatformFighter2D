using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HostGameTransition : IStageTransition
    {
        private BaseInitializer _gameInitializer = null;

        public HostGameTransition(BaseInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public BaseStage MakeTransition()
        {
            ResourceLoader.LoadHostGameStage();

            BaseStage hostGameStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.HOST_GAME_STAGE)) as BaseStage;

            hostGameStage.SetInitializer(_gameInitializer);
            hostGameStage.transform.parent = _gameInitializer.transform;
            hostGameStage.transform.localPosition = new Vector3(0f, 0f, 0f);
            hostGameStage.transform.localRotation = Quaternion.identity;

            return hostGameStage;
        }
    }
}