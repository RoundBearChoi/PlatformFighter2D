using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Death : UnitState
    {
        Unit _deathFX = null;

        public LittleRed_Death(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, BaseInitializer.current.fighterDataSO.IdleSlowDownLerpPercentage * 0.3f));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_DEATH);

            if (ownerUnit.unitType == UnitType.LITTLE_RED_LIGHT)
            {
                BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.DeathFX_Light);
                Unit fxLight = Units.instance.GetUnit<DeathFX_Light>();
                fxLight.transform.position = ownerUnit.transform.position;
                fxLight.unitData.facingRight = ownerUnit.unitData.facingRight;

                _deathFX = fxLight;
            }
            else if (ownerUnit.unitType == UnitType.LITTLE_RED_DARK)
            {
                BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.DeathFX_Dark);
                Unit fxDark = Units.instance.GetUnit<DeathFX_Dark>();
                fxDark.transform.position = ownerUnit.transform.position;
                fxDark.unitData.facingRight = ownerUnit.unitData.facingRight;

                _deathFX = fxDark;
            }
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_deathFX != null)
            {
                _deathFX.transform.position = ownerUnit.transform.position;
            }
        }
    }
}