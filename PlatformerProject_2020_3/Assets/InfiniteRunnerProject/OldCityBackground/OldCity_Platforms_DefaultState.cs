using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_Platforms_DefaultState : UnitState
    {
        public OldCity_Platforms_DefaultState(Unit unit)
        {
            _ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_PLATFORMS);

            _ownerUnit.transform.position = new Vector3(_ownerUnit.transform.position.x, _ownerUnit.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.OldCity_Platforms_z);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}