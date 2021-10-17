using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedAttackA : StateComponent
    {
        private uint _requiredIndexCount = 0;

        public TriggerLittleRedAttackA(Unit unit, uint requiredIndexCount)
        {
            _unit = unit;
            _requiredIndexCount = requiredIndexCount;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = _unit.unitData.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (ani.SPRITE_INDEX >= _requiredIndexCount &&
                    !_unit.unitData.AttackATriggered)
                {
                    if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, true))
                    {
                        if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == true && _unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == false)
                        {
                            _unit.unitData.facingRight = true;
                        }
                        else if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == false && _unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == true)
                        {
                            _unit.unitData.facingRight = false;
                        }

                        _unit.unitData.listNextStates.Add(new LittleRed_Attack_A(_unit));
                    }
                }
            } 
        }
    }
}