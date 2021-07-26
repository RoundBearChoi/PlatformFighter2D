using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_FrontTrees_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;
        public static Swamp_FrontTrees_DefaultState latest;

        public Swamp_FrontTrees_DefaultState(Unit unit)
        {
            ownerUnit = unit;
            latest = this;

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, GameInitializer.current.GetParallaxData(ParallaxDataType.SWAMP).Swamp_FrontTrees_ParallaxPercentage));
            _listStateComponents.Add(new DeletePassedBackground(unit));
            _listStateComponents.Add(new AddBackground<Swamp_FrontTrees_DefaultState>(this));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override UnitState GetLastestInstantiatedState()
        {
            return latest;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}