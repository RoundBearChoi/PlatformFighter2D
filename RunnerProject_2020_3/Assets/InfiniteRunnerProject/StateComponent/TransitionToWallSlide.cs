using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TransitionToWallSlide : StateComponent
    {
        public TransitionToWallSlide(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.iStateController.GetCurrentState().fixedUpdateCount >= 2)
            {
                List<Ground> grounds = _unit.unitData.collisionStays.GetSideTouchingGrounds();

                if (grounds.Count >= 2)
                {
                    Vector3 dir = _unit.transform.position - grounds[0].transform.position;
                    bool makeTransition = false;

                    if (dir.x > 0f)
                    {
                        if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_RIGHT))
                        {
                            makeTransition = true;
                        }
                    }
                    else if (dir.x < 0f)
                    {
                        if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT))
                        {
                            makeTransition = true;
                        }
                    }

                    if (makeTransition)
                    {
                        _unit.unitData.listNextStates.Add(new LittleRed_WallSlide(_unit));
                    }
                }
            }
        }
    }
}