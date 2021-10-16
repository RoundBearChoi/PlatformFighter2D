using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_Grass_DefaultState : UnitState
    {
        public static Swamp_Grass_DefaultState latest;

        public Swamp_Grass_DefaultState(Unit unit)
        {
            ownerUnit = unit;
            latest = this;

            _listStateComponents.Add(new HorizontalParallax(BaseInitializer.current.GetStage().CAMERA_SCRIPT, unit, unit.transform.position, BaseInitializer.current.swampParallaxSO.Swamp_Grass_ParallaxPercentage));
            _listStateComponents.Add(new DeletePassedBackground(BaseInitializer.current.GetStage().CAMERA_SCRIPT, unit));
            _listStateComponents.Add(new AddBackground<Swamp_Grass_DefaultState>(BaseInitializer.current.GetStage().CAMERA_SCRIPT, this));

            _listMatchingSpriteTypes.Add(SpriteType.SWAMP_GRASS);
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