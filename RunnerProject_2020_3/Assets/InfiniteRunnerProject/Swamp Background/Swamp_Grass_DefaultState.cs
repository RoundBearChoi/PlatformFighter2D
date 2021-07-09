using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_Grass_DefaultState : State
    {
        private static SpriteAnimationSpec _animationSpec;

        public Swamp_Grass_DefaultState(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, CameraController.gameCam.gameObject, StaticRefs.swampSpriteData.Swamp_Grass_ParallaxPercentage));
        }

        public override void OnFixedUpdate()
        {
            UpdateComponents();
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return _animationSpec;
        }
    }
}