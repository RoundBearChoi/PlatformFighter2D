using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LandingDust : Unit
    {
        public override void OnFixedUpdate()
        {
            unitData.spriteAnimations.OnFixedUpdate();
        }
    }
}