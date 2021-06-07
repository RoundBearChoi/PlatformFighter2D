using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SampleLeftEnemy : Unit
    {
        private void Start()
        {
            listDangerousSides.Clear();
            listDangerousSides.Add(CollisionType.LEFT);
        }

        public override void OnFixedUpdate()
        {
            unitUpdater.CustomFixedUpdate();
            spriteAnimations.OnFixedUpdate();
        }
    }
}