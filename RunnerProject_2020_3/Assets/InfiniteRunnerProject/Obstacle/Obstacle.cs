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

            foreach (SpriteAnimation ani in listSpriteAnimations)
            {
                ani.OnFixedUpdate();
            }
        }
    }
}