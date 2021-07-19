using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_River_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;

        public Swamp_River_DefaultState(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, GameInitializer.current.swampParallaxSO.Swamp_River_ParallaxPercentage));
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