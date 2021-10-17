using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StartTestGamingStage : UIOption
    {
        public override void OnEnterKey()
        {
            //BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.FIGHT_STAGE));
            BaseInitializer.CURRENT.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INPUT_DEVICES_STAGE));
        }
    }
}