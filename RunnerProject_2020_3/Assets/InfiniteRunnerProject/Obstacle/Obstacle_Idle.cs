using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle_Idle : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_White100x100");

        public Obstacle_Idle(UnitData data)
        {
            _unitData = data;
        }

        public override void OnEnter()
        {

        }

        public override void Update()
        {

        }

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }
    }
}