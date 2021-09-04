using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class JoinGame : UIOption
    {
        public override void OnEnterKey()
        {
            GameInitializer.current.stageTransitioner.AddTransition(new EnterIPStageTransition(GameInitializer.current));
        }
    }
}