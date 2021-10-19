using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_TopFog_DefaultState : UnitState
    {
        public OldCity_TopFog_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_TOP_FOG);
        }

        public override void OnEnter()
        {
            _listStateComponents.Add(new HorizontalParallax(this, ownerUnit.transform.position, BaseInitializer.CURRENT.oldCityParallaxSO.OldCity_Pillars_ParallaxPercentage));
            ownerUnit.transform.position = new Vector3(ownerUnit.transform.position.x, ownerUnit.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.OldCity_BottomFog_z);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}