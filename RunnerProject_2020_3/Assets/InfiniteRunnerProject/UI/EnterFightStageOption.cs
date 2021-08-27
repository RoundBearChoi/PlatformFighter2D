using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class EnterFightStageOption : UIOption
    {
        public override void OnEnterKey()
        {
            GameInitializer.current.stageTransitioner.AddTransition(new FightStageTransition(GameInitializer.current));
        }
    }
}