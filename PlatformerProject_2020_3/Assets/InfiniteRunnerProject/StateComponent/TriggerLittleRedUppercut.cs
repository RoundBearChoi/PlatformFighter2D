using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedUppercut : StateComponent
    {
        uint _requiredIndexCount = 0;

        public TriggerLittleRedUppercut(UnitState unitState, uint requriedIndexCount)
        {
            _unitState = unitState;
            _requiredIndexCount = requriedIndexCount;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = UNIT.spriteAnimations.GetCurrentAnimation();

            if (ani != null && !UNIT_DATA.airControl.UppercutTriggered)
            {
                if (ani.SPRITE_INDEX >= _requiredIndexCount)
                {
                    if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_UP, false))
                    {
                        if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, true))
                        {
                            UNIT_DATA.airControl.UppercutTriggered = true;
                            UNIT.listNextStates.Add(new LittleRedUppercut());
                        }
                    }
                }
            }
        }
    }
}