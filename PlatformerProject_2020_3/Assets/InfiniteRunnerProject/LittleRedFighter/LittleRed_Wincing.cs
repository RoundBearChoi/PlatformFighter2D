using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Wincing : UnitState
    {
        public LittleRed_Wincing(Unit unit, Vector2 pushForce, Unit attacker)
        {
            ownerUnit = unit;
            noHitStopAllowed = true;

            _listStateComponents.Add(new InitialPushBack(this, pushForce, attacker));
            _listStateComponents.Add(new InitialTextGUIMaterial(this, 8));
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, BaseInitializer.CURRENT.fighterDataSO.IdleSlowDownLerpPercentage));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_IDLE);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.hp <= 0)
            {
                if (ownerUnit.unitData.collisionStays.IsOnFlatGround())
                {
                    ownerUnit.gameObject.layer = (int)LayerType.GHOSTING_UNIT;
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Death(ownerUnit));
                }
            }

            if (fixedUpdateCount >= 20)
            {
                if (ownerUnit.unitData.hp > 0)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle());
                }
            }
        }
    }
}