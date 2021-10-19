using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedAttackB : StateComponent
    {
        private uint _requiredIndexCount = 0;

        public TriggerLittleRedAttackB(UnitState unitState, uint requiredIndexCount)
        {
            _unitState = unitState;
            _requiredIndexCount = requiredIndexCount;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = UNIT.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (ani.SPRITE_INDEX >= _requiredIndexCount)
                {
                    if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, true))
                    {
                        UNIT.listNextStates.Add(new LittleRed_Attack_B());
                    }
                }
            }
        }
    }
}