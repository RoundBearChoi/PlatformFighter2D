using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class EnterIPStageTransition : IStageTransition
    {
        private BaseInitializer _gameInitializer = null;

        public EnterIPStageTransition(BaseInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public BaseStage MakeTransition()
        {
            ResourceLoader.LoadHostGameStage();

            BaseStage enterIPStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.ENTER_IP_STAGE)) as BaseStage;

            enterIPStage.SetInitializer(_gameInitializer);
            enterIPStage.transform.parent = _gameInitializer.transform;
            enterIPStage.transform.localPosition = new Vector3(0f, 0f, 0f);
            enterIPStage.transform.localRotation = Quaternion.identity;

            return enterIPStage;
        }
    }
}