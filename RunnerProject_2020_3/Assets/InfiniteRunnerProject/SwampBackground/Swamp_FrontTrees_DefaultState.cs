using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_FrontTrees_DefaultState : State
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
                hashString = StaticRefs.swampSpriteData.Swamp_FrontTrees_SpriteName;
                animationHash = Hash128.Compute(hashString);
            }
        }

        public Swamp_FrontTrees_DefaultState(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, CameraController.gameCam.gameObject, StaticRefs.swampSpriteData.Swamp_FrontTrees_ParallaxPercentage));
        }

        public override void OnFixedUpdate()
        {
            UpdateComponents();
        }
    }
}