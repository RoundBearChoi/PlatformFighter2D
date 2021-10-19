using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Run : UnitState
    {
        public LittleRed_Run()
        {
            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_RUN);
        }

        public override void OnEnter()
        {
            float runspeed = BaseInitializer.CURRENT.fighterDataSO.DefaultRunSpeed;

            if (!ownerUnit.facingRight)
            {
                runspeed *= -1f;
            }

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, runspeed, BaseInitializer.CURRENT.fighterDataSO.RunSpeedLerpPercentage));
            _listStateComponents.Add(new Create_LittleRed_Run_StepDust(this));
            _listStateComponents.Add(new SetDefaultAnimationInterval(this));

            _listStateComponents.Add(new TriggerIdleOnGround(this));
            _listStateComponents.Add(new TriggerGroundRoll(this));
            _listStateComponents.Add(new TriggerLittleRedUppercut(this, 0));
            _listStateComponents.Add(new TriggerLittleRedAttackA(this, 0));
            _listStateComponents.Add(new TriggerFallState(this));
            _listStateComponents.Add(new TriggerJumpUp(this));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}