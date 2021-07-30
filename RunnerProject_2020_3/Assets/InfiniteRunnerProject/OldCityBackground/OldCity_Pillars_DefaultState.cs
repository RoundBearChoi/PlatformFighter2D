using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_Pillars_DefaultState : UnitState
    {
        public OldCity_Pillars_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, GameInitializer.current.oldCityParallaxSO.OldCity_Pillars_ParallaxPercentage));

            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_PILLARS);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}