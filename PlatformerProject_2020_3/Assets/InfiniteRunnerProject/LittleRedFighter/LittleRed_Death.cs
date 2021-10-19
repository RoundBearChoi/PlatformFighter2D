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
            _ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, BaseInitializer.CURRENT.fighterDataSO.IdleSlowDownLerpPercentage * 0.3f));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_DEATH);

            if (_ownerUnit.unitType == UnitType.LITTLE_RED_LIGHT)
            {
                BaseInitializer.CURRENT.STAGE.InstantiateUnit_ByUnitType(UnitType.DeathFX_Light, new DeathFX_Light_DefaultState());
                _deathFX = Units.instance.GetUnit<DeathFX_Light>();
            }
            else if (_ownerUnit.unitType == UnitType.LITTLE_RED_DARK)
            {
                BaseInitializer.CURRENT.STAGE.InstantiateUnit_ByUnitType(UnitType.DeathFX_Dark, new DeathFX_Dark_DefaultState());
                 _deathFX = Units.instance.GetUnit<DeathFX_Dark>();
            }

            UpdateDeathFXPosition();

            _ownerUnit.transform.position = new Vector3(_ownerUnit.transform.position.x, _ownerUnit.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.DeadPlayers_z);
            _ownerUnit.gameObject.layer = (int)LayerType.GHOSTING_UNIT;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            UpdateDeathFXPosition();
        }

        void UpdateDeathFXPosition()
        {
            if (_deathFX != null)
            {
                _deathFX.facingRight = _ownerUnit.facingRight;
                _deathFX.transform.position = new Vector3(_ownerUnit.transform.position.x, _ownerUnit.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.Player_DeathParticles_z);
            }
        }
    }
}