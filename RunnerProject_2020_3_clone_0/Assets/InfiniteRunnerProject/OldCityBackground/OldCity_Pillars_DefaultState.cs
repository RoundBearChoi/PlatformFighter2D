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

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, BaseInitializer.current.oldCityParallaxSO.OldCity_Pillars_ParallaxPercentage));

            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_PILLARS);

            ownerUnit.transform.position = new Vector3(ownerUnit.transform.position.x, ownerUnit.transform.position.y, BaseInitializer.current.fighterDataSO.OldCity_Pillars_z);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}