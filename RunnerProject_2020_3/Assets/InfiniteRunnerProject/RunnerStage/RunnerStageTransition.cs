using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStageTransition : IStageTransition
    {
        private GameInitializer _gameInitializer = null;

        public RunnerStageTransition(GameInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public Stage MakeTransition()
        {
            Stage runnerStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.RUNNER_STAGE)) as Stage;
            runnerStage.SetInitializer(_gameInitializer);
            runnerStage.transform.parent = _gameInitializer.transform;
            runnerStage.transform.localPosition = new Vector3(0f, -3f, 0f); //testing stage position
            runnerStage.transform.localRotation = Quaternion.identity;

            return runnerStage;
        }
    }
}