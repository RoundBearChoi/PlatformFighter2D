using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HostGame : UIOption
    {
        public override void OnEnterKey()
        {
            GameInitializer.current.stageTransitioner.AddTransition(new HostGameTransition(GameInitializer.current));
        }
    }
}