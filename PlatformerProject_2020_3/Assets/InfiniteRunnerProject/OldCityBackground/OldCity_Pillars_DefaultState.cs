using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_Pillars_DefaultState : UnitState
    {
        public OldCity_Pillars_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_PILLARS);
        }

        public override void OnEnter()
        {
            _listStateComponents.Add(new HorizontalParallax(this, _ownerUnit.transform.position, BaseInitializer.CURRENT.oldCityParallaxSO.OldCity_Pillars_ParallaxPercentage));
            _ownerUnit.transform.position = new Vector3(_ownerUnit.transform.position.x, _ownerUnit.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.OldCity_Pillars_z);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}