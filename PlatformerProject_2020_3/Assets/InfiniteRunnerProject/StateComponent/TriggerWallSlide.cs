using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerWallSlide : StateComponent
    {
        public TriggerWallSlide(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT.iStateController.GetCurrentState().fixedUpdateCount >= 2)
            {
                List<CollisionData> grounds = UNIT_DATA.collisionStays.GetSideTouchingGrounds();

                if (grounds.Count >= 2)
                {
                    bool makeTransition = false;

                    if (grounds[0].contactPoint.point.x < UNIT.transform.position.x)
                    {
                        if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false))
                        {
                            makeTransition = true;
                        }
                    }
                    else if (grounds[0].contactPoint.point.x > UNIT.transform.position.x)
                    {
                        if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false))
                        {
                            makeTransition = true;
                        }
                    }

                    if (makeTransition)
                    {
                        UNIT_DATA.listNextStates.Add(new LittleRed_WallSlide());
                    }
                }
            }
        }
    }
}