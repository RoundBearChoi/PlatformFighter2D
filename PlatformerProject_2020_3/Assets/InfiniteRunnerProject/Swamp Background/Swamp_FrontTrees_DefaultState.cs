using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_FrontTrees_DefaultState : UnitState
    {
        public static Swamp_FrontTrees_DefaultState latest;

        public Swamp_FrontTrees_DefaultState(Unit unit)
        {
            ownerUnit = unit;
            latest = this;

            _listStateComponents.Add(new HorizontalParallax(BaseInitializer.current.GetStage().CAMERA_SCRIPT, unit, unit.transform.position, BaseInitializer.current.swampParallaxSO.Swamp_FrontTrees_ParallaxPercentage));
            _listStateComponents.Add(new DeletePassedBackground(BaseInitializer.current.GetStage().CAMERA_SCRIPT, unit));
            _listStateComponents.Add(new AddBackground<Swamp_FrontTrees_DefaultState>(BaseInitializer.current.GetStage().CAMERA_SCRIPT, this));

            _listMatchingSpriteTypes.Add(SpriteType.SWAMP_FRONTTREES);
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