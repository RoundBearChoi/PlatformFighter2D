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
            SpriteAnimation ani = UNIT.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (ani.SPRITE_INDEX >= _requiredIndexCount &&
                    !UNIT.attack_A_Triggered)
                {
                    if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, true))
                    {
                        if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == true && UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == false)
                        {
                            UNIT.facingRight = true;
                        }
                        else if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == false && UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == true)
                        {
                            UNIT.facingRight = false;
                        }

                        UNIT.listNextStates.Add(new LittleRed_Attack_A());
                    }
                }
            } 
        }
    }
}