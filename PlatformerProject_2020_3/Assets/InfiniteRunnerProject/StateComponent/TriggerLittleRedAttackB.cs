using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedAttackB : StateComponent
    {
        private uint _requiredIndexCount = 0;

        public TriggerLittleRedAttackB(Unit unit, uint requiredIndexCount)
        {
            _unit = unit;
            _requiredIndexCount = requiredIndexCount;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = _unit.unitData.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (ani.SPRITE_INDEX >= _requiredIndexCount)
                {
                    if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
                    {
                        _unit.unitData.listNextStates.Add(new LittleRed_Attack_B(_unit));
                    }
                }
            }
        }
    }
}