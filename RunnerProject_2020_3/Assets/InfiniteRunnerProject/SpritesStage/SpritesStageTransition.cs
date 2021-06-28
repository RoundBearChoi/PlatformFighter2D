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
            Stage spritesStage = GameObject.Instantiate(ResourceLoader.GetResource(typeof(SpritesStage))) as Stage;
            spritesStage.SetInitializer(_gameInitializer);
            spritesStage.transform.parent = _gameInitializer.transform;
            spritesStage.transform.localPosition = Vector3.zero;
            spritesStage.transform.localRotation = Quaternion.identity;

            spritesStage.Init();

            return spritesStage;
        }
    }
}