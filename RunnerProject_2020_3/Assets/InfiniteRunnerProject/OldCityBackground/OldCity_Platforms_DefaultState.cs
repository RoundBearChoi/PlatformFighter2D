using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_Platforms_DefaultState : UnitState
    {
        public OldCity_Platforms_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.OLDCITY_PLATFORMS);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}