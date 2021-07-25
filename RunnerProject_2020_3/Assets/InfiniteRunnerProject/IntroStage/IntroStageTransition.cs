using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class IntroStageTransition : IStageTransition
    {
        private GameInitializer _gameInitializer = null;

        public IntroStageTransition(GameInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public BaseStage MakeTransition()
        {
            BaseStage introStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.INTRO_STAGE)) as BaseStage;
            introStage.SetInitializer(_gameInitializer);
            introStage.transform.parent = _gameInitializer.transform;
            introStage.transform.localPosition = Vector3.zero;
            introStage.transform.localRotation = Quaternion.identity;

            return introStage;
        }
    }
}