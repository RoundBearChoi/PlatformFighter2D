using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_BottomFog_DefaultState : UnitState
    {
        public OldCity_BottomFog_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, GameInitializer.current.oldCityParallaxSO.OldCity_Pillars_ParallaxPercentage));

            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_BOTTOMFOG);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}