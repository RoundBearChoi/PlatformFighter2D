using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ReturnToMenu : UIOption
    {
        public override void OnEnterKey()
        {
            GameInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE, GameInitializer.current));
        }
    }
}