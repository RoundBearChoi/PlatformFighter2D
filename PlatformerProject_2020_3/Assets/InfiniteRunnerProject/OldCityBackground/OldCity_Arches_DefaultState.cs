using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_Arches_DefaultState : UnitState
    {
        public OldCity_Arches_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_ARCHES);
        }

        public override void OnEnter()
        {
            _listStateComponents.Add(new HorizontalParallax(this, ownerUnit.transform.position, BaseInitializer.CURRENT.oldCityParallaxSO.OldCity_Arches_ParallaxPercentage));
            ownerUnit.transform.position = new Vector3(ownerUnit.transform.position.x, ownerUnit.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.OldCity_Arches_z);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}