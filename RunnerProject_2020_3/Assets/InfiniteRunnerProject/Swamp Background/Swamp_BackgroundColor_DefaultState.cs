using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_BackgroundColor_DefaultState : State
    {
        private static SpriteAnimationSpec _animationSpec;

        public Swamp_BackgroundColor_DefaultState(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, GameInitializer.current.swampParallaxSO.Swamp_BackgroundColor_ParallaxPercentage));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return _animationSpec;
        }
    }
}