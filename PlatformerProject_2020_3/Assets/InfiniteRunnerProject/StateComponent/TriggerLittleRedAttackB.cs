using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedAttackB : StateComponent
    {
        public TriggerLittleRedAttackB(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
            {
                SpriteAnimation ani = _unit.unitData.spriteAnimations.GetCurrentAnimation();

                if (ani != null)
                {
                    if (ani.SPRITE_INDEX >= 2)
                    {
                        if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
                        {
                            Debugger.Log("trigger attack B!");
                            //_unit.unitData.listNextStates.Add(new LittleRed_Attack_B(_unit));
                        }
                    }
                }
            }
        }
    }
}