using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_Grass_DefaultState : State
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
                hashString = "Texture_Swamp_Grass -1";
                animationHash = Hash128.Compute(hashString);
            }
        }

        public Swamp_Grass_DefaultState(Unit unit)
        {
            _unit = unit;
        }
    }
}