using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameStageTransition : IStageTransition
    {
        private GameInitializer _gameInitializer = null;

        public GameStageTransition(GameInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public Stage MakeTransition()
        {
            Stage gameStage = GameObject.Instantiate(ResourceLoader.Get(typeof(GameStage))) as Stage;
            gameStage.SetInitializer(_gameInitializer);
            gameStage.transform.parent = _gameInitializer.transform;
            gameStage.transform.localPosition = Vector3.zero;
            gameStage.transform.localRotation = Quaternion.identity;

            gameStage.Init();

            return gameStage;
        }
    }
}