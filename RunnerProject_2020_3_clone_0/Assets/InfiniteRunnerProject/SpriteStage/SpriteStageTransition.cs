using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteStageTransition : IStageTransition
    {
        private BaseInitializer _gameInitializer = null;

        public SpriteStageTransition(BaseInitializer initializer)
        {
            _gameInitializer = initializer;
        }

        public BaseStage MakeTransition()
        {
            BaseStage spritesStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.SPRITE_STAGE)) as BaseStage;
            spritesStage.SetInitializer(_gameInitializer);
            spritesStage.transform.parent = _gameInitializer.transform;
            spritesStage.transform.localPosition = Vector3.zero;
            spritesStage.transform.localRotation = Quaternion.identity;

            return spritesStage;
        }
    }
}