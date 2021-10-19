using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Create_LittleRed_Roll_StepDust : StateComponent
    {
        public Create_LittleRed_Roll_StepDust(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (!UNIT.isDummy)
            {
                SpriteAnimation ani = UNIT_DATA.spriteAnimations.GetCurrentAnimation();

                if (ani != null)
                {
                    if (ani.SPRITE_INDEX == 1 ||
                        ani.SPRITE_INDEX == 3 ||
                        ani.SPRITE_INDEX == 5)
                    {
                        uint fixedUpdateCount = UNIT.iStateController.GetCurrentState().fixedUpdateCount;

                        if (fixedUpdateCount != 0 && fixedUpdateCount % ani.SPRITE_INTERVAL == 0)
                        {
                            BaseMessage showStepDust = new Message_ShowStepDust(false, UNIT.transform.position - new Vector3(UNIT.transform.right.x * 0.025f, 0f, 0f), new Vector2(1f, 1f), 4);
                            showStepDust.Register();
                        }
                    }
                }
            }
        }
    }
}