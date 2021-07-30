using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_BackTrees_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;
        public static Swamp_BackTrees_DefaultState latest;

        public Swamp_BackTrees_DefaultState(Unit unit)
        {
            ownerUnit = unit;
            latest = this;

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, GameInitializer.current.swampParallaxSO.Swamp_BackTrees_ParallaxPercentage));
            _listStateComponents.Add(new DeletePassedBackground(unit));
            _listStateComponents.Add(new AddBackground<Swamp_BackTrees_DefaultState>(this));

            _listMatchingSpriteTypes.Add(SpriteType.SWAMP_BACKTREES);
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