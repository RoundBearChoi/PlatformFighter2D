using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_Background_DefaultState : UnitState
    {
        public OldCity_Background_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_BACKGROUND);
        }

        public override void OnEnter()
        {
            _listStateComponents.Add(new HorizontalParallax(this, _ownerUnit.transform.position, BaseInitializer.CURRENT.oldCityParallaxSO.OldCity_Background_ParallaxPercentage));
            _ownerUnit.transform.position = new Vector3(_ownerUnit.transform.position.x, _ownerUnit.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.OldCity_Background_z);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}