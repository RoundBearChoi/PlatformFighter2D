using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_River_DefaultState : State
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
                hashString = StaticRefs.swampSpriteData.Swamp_River_SpriteName;
                animationHash = Hash128.Compute(hashString);
            }
        }

        public Swamp_River_DefaultState(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, CameraController.gameCam.gameObject, StaticRefs.swampSpriteData.Swamp_River_ParallaxPercentage));
        }

        public override void OnFixedUpdate()
        {
            UpdateComponents();
        }
    }
}