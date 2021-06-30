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
            Stage runnerStage = GameObject.Instantiate(ResourceLoader.GetResource(typeof(RunnerStage))) as Stage;
            runnerStage.SetInitializer(_gameInitializer);
            runnerStage.transform.parent = _gameInitializer.transform;
            runnerStage.transform.localPosition = Vector3.zero;
            runnerStage.transform.localRotation = Quaternion.identity;

            runnerStage.Init();

            return runnerStage;
        }
    }
}