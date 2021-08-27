using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FightStageTransition : IStageTransition
    {
        private BaseInitializer _gameInitializer = null;

        public FightStageTransition(BaseInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public BaseStage MakeTransition()
        {
            ResourceLoader.LoadFightStage();

            BaseStage runnerStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.FIGHT_STAGE)) as BaseStage;
            runnerStage.SetInitializer(_gameInitializer);
            runnerStage.transform.parent = _gameInitializer.transform;
            runnerStage.transform.localPosition = new Vector3(0f, 0f, 0f);
            runnerStage.transform.localRotation = Quaternion.identity;

            return runnerStage;
        }
    }
}