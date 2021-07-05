using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle_Idle : State
    {
        static Hash128 animationHash;
        static string hashString = string.Empty;

        private Unit _runner = null;

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public override void SetHashString()
        {
            if (string.IsNullOrEmpty(hashString))
            {
                hashString = "Texture_BlockEnemy";
                animationHash = Hash128.Compute(hashString);
            }
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