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
            _listStateComponents.Add(new HorizontalParallax(this, _ownerUnit.transform.position, BaseInitializer.CURRENT.oldCityParallaxSO.OldCity_Pillars_ParallaxPercentage));
            _ownerUnit.transform.position = new Vector3(_ownerUnit.transform.position.x, _ownerUnit.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.OldCity_BottomFog_z);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}