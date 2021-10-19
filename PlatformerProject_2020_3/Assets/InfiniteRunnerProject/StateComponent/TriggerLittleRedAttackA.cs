using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedAttackA : StateComponent
    {
        private uint _requiredIndexCount = 0;

        public TriggerLittleRedAttackA(UnitState unitState, uint requiredIndexCount)
        {
            _unitState = unitState;
            _requiredIndexCount = requiredIndexCount;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = UNIT_DATA.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (ani.SPRITE_INDEX >= _requiredIndexCount &&
                    !UNIT_DATA.AttackATriggered)
                {
                    if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, true))
                    {
                        if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == true && UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == false)
                        {
                            UNIT_DATA.facingRight = true;
                        }
                        else if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == false && UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == true)
                        {
                            UNIT_DATA.facingRight = false;
                        }

                        UNIT_DATA.listNextStates.Add(new LittleRed_Attack_A());
                    }
                }
            } 
        }
    }
}