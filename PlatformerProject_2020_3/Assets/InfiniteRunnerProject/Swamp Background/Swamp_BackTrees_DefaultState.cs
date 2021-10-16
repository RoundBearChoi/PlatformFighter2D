using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_BackTrees_DefaultState : UnitState
    {
        public static Swamp_BackTrees_DefaultState latest;

        public Swamp_BackTrees_DefaultState(Unit unit)
        {
            ownerUnit = unit;
            latest = this;

            _listStateComponents.Add(new HorizontalParallax(BaseInitializer.current.GetStage().CAMERA_SCRIPT, unit, unit.transform.position, BaseInitializer.current.swampParallaxSO.Swamp_BackTrees_ParallaxPercentage));
            _listStateComponents.Add(new DeletePassedBackground(BaseInitializer.current.GetStage().CAMERA_SCRIPT, unit));
            _listStateComponents.Add(new AddBackground<Swamp_BackTrees_DefaultState>(BaseInitializer.current.GetStage().CAMERA_SCRIPT, this));

            _listMatchingSpriteTypes.Add(SpriteType.SWAMP_BACKTREES);
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