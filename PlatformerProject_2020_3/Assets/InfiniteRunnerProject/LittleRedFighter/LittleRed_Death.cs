using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Death : UnitState
    {
        public LittleRed_Death(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, BaseInitializer.current.fighterDataSO.IdleSlowDownLerpPercentage * 0.3f));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_DEATH);

            if (ownerUnit.unitType == UnitType.LITTLE_RED_LIGHT)
            {

            }
            else if (ownerUnit.unitType == UnitType.LITTLE_RED_DARK)
            {
                BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.DeathFX_Dark);
                Unit fxDark = Units.instance.GetUnit<DeathFX_Dark>();
                fxDark.transform.position = ownerUnit.transform.position;
                fxDark.unitData.facingRight = ownerUnit.unitData.facingRight;
            }
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}