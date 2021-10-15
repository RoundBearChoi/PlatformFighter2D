using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Create_LittleRed_Roll_StepDust : StateComponent
    {
        public Create_LittleRed_Roll_StepDust(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            uint fixedUpdateCount = _unit.iStateController.GetCurrentState().fixedUpdateCount;

            if (fixedUpdateCount != 0 && fixedUpdateCount % _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INTERVAL == 0)
            {
                if (_unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 1 ||
                    _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 3 ||
                    _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 5)
                {
                    if (!_unit.isDummy)
                    {
                        BaseMessage showStepDust = new Message_ShowStepDust(false, _unit.transform.position - new Vector3(_unit.transform.right.x * 0.025f, 0f, 0f), new Vector2(1f, 1f), 4);
                        showStepDust.Register();
                    }
                }
            }
        }
    }
}