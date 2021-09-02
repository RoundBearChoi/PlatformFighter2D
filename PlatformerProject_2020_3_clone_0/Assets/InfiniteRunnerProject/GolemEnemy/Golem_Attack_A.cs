using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Attack_A : UnitState
    {
        public Golem_Attack_A(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new OverlapBoxCollision(ownerUnit, BaseInitializer.current.GetOverlapBoxCollisionData(OverlapBoxDataType.GOLEM_ATTACK_A)));

            _listMatchingSpriteTypes.Add(SpriteType.GOLEM_ATTACK_A);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                ownerUnit.unitData.listNextStates.Add(new Golem_Idle(ownerUnit));
            }
        }
    }
}