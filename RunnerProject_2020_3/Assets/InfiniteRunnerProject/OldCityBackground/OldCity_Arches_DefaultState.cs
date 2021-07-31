using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_Arches_DefaultState : UnitState
    {
        public OldCity_Arches_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, GameInitializer.current.oldCityParallaxSO.OldCity_Arches_ParallaxPercentage));

            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_ARCHES);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}