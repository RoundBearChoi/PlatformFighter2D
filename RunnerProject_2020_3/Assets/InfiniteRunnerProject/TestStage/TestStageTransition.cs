using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TestStageTransition : IStageTransition
    {
        private GameInitializer _gameInitializer = null;

        public TestStageTransition(GameInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public BaseStage MakeTransition()
        {
            BaseStage testStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.TEST_STAGE)) as BaseStage;
            testStage.SetInitializer(_gameInitializer);
            testStage.transform.parent = _gameInitializer.transform;
            testStage.transform.localPosition = new Vector3(0f, 10f, 0f); //testing stage position
            testStage.transform.localRotation = Quaternion.identity;

            return testStage;
        }
    }
}