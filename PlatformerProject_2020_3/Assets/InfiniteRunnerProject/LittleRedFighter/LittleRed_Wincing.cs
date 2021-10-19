using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Wincing : UnitState
    {
        public LittleRed_Wincing(Unit unit, Vector2 pushForce, Unit attacker)
        {
            _ownerUnit = unit;
            noHitStopAllowed = true;

            _listStateComponents.Add(new InitialPushBack(this, pushForce, attacker));
            _listStateComponents.Add(new InitialTextGUIMaterial(this, 8));
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, BaseInitializer.CURRENT.fighterDataSO.IdleSlowDownLerpPercentage));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_IDLE);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.hp <= 0)
            {
                if (_ownerUnit.unitData.collisionStays.IsOnFlatGround())
                {
                    _ownerUnit.gameObject.layer = (int)LayerType.GHOSTING_UNIT;
                    _ownerUnit.listNextStates.Add(new LittleRed_Death(_ownerUnit));
                }
            }

            if (fixedUpdateCount >= 20)
            {
                if (_ownerUnit.hp > 0)
                {
                    _ownerUnit.listNextStates.Add(new LittleRed_Idle());
                }
            }
        }
    }
}