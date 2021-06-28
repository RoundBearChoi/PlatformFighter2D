using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpritesStageTransition : IStageTransition
    {
        private GameInitializer _gameInitializer = null;

        public SpritesStageTransition(GameInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public Stage MakeTransition()
        {
            //Stage gameStage = GameObject.Instantiate(ResourceLoader.GetResource(typeof(GameStage))) as Stage;
            //gameStage.SetInitializer(_gameInitializer);
            //gameStage.transform.parent = _gameInitializer.transform;
            //gameStage.transform.localPosition = Vector3.zero;
            //gameStage.transform.localRotation = Quaternion.identity;
            //
            //gameStage.Init();
            //
            //return gameStage;

            Stage spritesStage = GameObject.Instantiate(ResourceLoader.GetResource(typeof(SpritesStage))) as Stage;
            spritesStage.transform.parent = _gameInitializer.transform;
            spritesStage.transform.localPosition = Vector3.zero;
            spritesStage.transform.localRotation = Quaternion.identity;

            return spritesStage;
        }
    }
}