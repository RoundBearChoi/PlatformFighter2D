using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FrontEnemy_Idle : State
    {
        static Hash128 animationHash;
        static string hashString = string.Empty;

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public override void SetHashString()
        {
            if (string.IsNullOrEmpty(hashString))
            {
                hashString = "Texture_Front_Enemy_Sample";
                animationHash = Hash128.Compute(hashString);
            }
        }

        public FrontEnemy_Idle(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {

        }
    }
}