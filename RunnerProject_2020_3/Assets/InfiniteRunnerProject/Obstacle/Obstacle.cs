using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle : Unit
    {
        public override void OnFixedUpdate()
        {
            unitUpdater.CustomUpdate();

            spriteAnimations.OnFixedUpdate();
        }
    }
}