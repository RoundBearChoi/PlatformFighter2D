using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedUppercut : StateComponent
    {
        uint _requiredIndexCount = 0;

        public TriggerLittleRedUppercut(Unit unit, uint requriedIndexCount)
        {
            _unit = unit;
            _requiredIndexCount = requriedIndexCount;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = _unit.unitData.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (ani.SPRITE_INDEX >= _requiredIndexCount)
                {
                    if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_UP, false))
                    {
                        if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
                        {
                            Debugger.Log("uppercut!");
                            _unit.unitData.listNextStates.Add(new LittleRedUppercut(_unit));
                        }
                    }
                }
            }
        }
    }
}