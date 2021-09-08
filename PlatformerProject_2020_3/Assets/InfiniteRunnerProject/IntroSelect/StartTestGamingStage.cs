using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StartTestGamingStage : UIOption
    {
        public override void OnEnterKey()
        {
            GameInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.FIGHT_STAGE, GameInitializer.current));
        }
    }
}