using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_Background_DefaultState : UnitState
    {
        public OldCity_Background_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new HorizontalParallax(BaseInitializer.current.GetStage().CAMERA_SCRIPT, unit, unit.transform.position, BaseInitializer.current.oldCityParallaxSO.OldCity_Background_ParallaxPercentage));

            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_BACKGROUND);

            ownerUnit.transform.position = new Vector3(ownerUnit.transform.position.x, ownerUnit.transform.position.y, BaseInitializer.current.fighterDataSO.OldCity_Background_z);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}