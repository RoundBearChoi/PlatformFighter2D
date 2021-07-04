using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle_Idle : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_BlockEnemy");

        private Unit _runner = null;

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Obstacle_Idle(Unit unit, Unit runner)
        {
            _unit = unit;
            _runner = runner;
        }

        public override void OnEnter()
        {

        }

        public override void OnFixedUpdate()
        {
            if (_runner.transform.position.x >= _unit.unitData.unitTransform.position.x + 15f)
            {
                //_unitData.destroy = true;
            }
        }


    }
}