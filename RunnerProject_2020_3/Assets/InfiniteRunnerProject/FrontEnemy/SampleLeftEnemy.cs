using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SampleLeftEnemy : Unit
    {
        private void Start()
        {
            attackData.AddAttackingSide(CollisionType.LEFT);
        }

        public override void OnFixedUpdate()
        {
            unitUpdater.CustomFixedUpdate();
            unitData.spriteAnimations.OnFixedUpdate();
        }

        public override void RunDeathAnimation()
        {
            destroy = true;
        }
    }
}