using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_River_DefaultState : UnitState
    {
        public static Swamp_River_DefaultState latest;

        public Swamp_River_DefaultState(Unit unit)
        {
            ownerUnit = unit;
            latest = this;

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, BaseInitializer.current.swampParallaxSO.Swamp_River_ParallaxPercentage));
            _listStateComponents.Add(new DeletePassedBackground(unit));
            _listStateComponents.Add(new AddBackground<Swamp_River_DefaultState>(this));

            _listMatchingSpriteTypes.Add(SpriteType.SWAMP_RIVER);
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