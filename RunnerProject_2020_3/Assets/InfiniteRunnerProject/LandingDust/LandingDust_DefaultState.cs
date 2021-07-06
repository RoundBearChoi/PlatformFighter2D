using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LandingDust_DefaultState : State
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
                hashString = "Texture_PrototypeHero_LandingDust";
                animationHash = Hash128.Compute(hashString);
            }
        }

        public LandingDust_DefaultState(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {

        }
    }
}