using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Create_LittleRed_Run_StepDust : StateComponent
    {
        public Create_LittleRed_Run_StepDust(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            uint fixedUpdateCount = UNIT.iStateController.GetCurrentState().fixedUpdateCount;

            if (fixedUpdateCount != 0 && fixedUpdateCount % UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_INTERVAL == 0)
            {
                if (UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 1 ||
                    UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 6)
                {
                    if (!UNIT.isDummy)
                    {
                        BaseMessage showStepDust = new Message_ShowStepDust(false, UNIT.transform.position - new Vector3(UNIT.transform.right.x * 0.025f, 0f, 0f), new Vector2(1f, 1f), 4);
                        showStepDust.Register();
                    }
                }
            }
        }
    }
}