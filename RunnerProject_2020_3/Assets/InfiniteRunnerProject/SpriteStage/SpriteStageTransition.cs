using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteStageTransition : IStageTransition
    {
        private GameInitializer _gameInitializer = null;

        public SpriteStageTransition(GameInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public Stage MakeTransition()
        {
            Stage spritesStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.SPRITE_STAGE)) as Stage;
            spritesStage.SetInitializer(_gameInitializer);
            spritesStage.transform.parent = _gameInitializer.transform;
            spritesStage.transform.localPosition = Vector3.zero;
            spritesStage.transform.localRotation = Quaternion.identity;

            return spritesStage;
        }
    }
}