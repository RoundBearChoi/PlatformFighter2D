using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_Grass_DefaultState : State
    {
        public static SpriteAnimationSpec animationSpec;

        public Swamp_Grass_DefaultState(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, GameInitializer.current.swampParallaxSO.Swamp_Grass_ParallaxPercentage));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}