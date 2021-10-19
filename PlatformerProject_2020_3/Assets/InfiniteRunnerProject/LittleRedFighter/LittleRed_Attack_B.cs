using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Attack_B : UnitState
    {
        public LittleRed_Attack_B()
        {
            disallowTransitionQueue = true;

            _listStateComponents.Add(new CancelJumpForceOnNonPress(this, 0));
            
            _listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(this, BaseInitializer.CURRENT.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new UpdateAirMovementOnMomentum(this));

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, BaseInitializer.CURRENT.fighterDataSO.AttackASlowDownPercentage));
            _listStateComponents.Add(new OverlapBoxCollision(this, BaseInitializer.CURRENT.GetOverlapBoxCollisionData(OverlapBoxDataType.LITTLE_RED_ATTACK_B)));

            _listStateComponents.Add(new TriggerLittleRedUppercut(this, 4));
            _listStateComponents.Add(new TriggerMarioStomp(this));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_ATTACK_B);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                ownerUnit.listNextStates.Add(new LittleRed_Idle());
            }
        }
    }
}