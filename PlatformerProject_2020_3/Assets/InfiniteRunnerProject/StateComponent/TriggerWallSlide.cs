using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerWallSlide : StateComponent
    {
        public TriggerWallSlide(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.iStateController.GetCurrentState().fixedUpdateCount >= 2)
            {
                List<CollisionData> grounds = _unit.unitData.collisionStays.GetSideTouchingGrounds();

                if (grounds.Count >= 2)
                {
                    bool makeTransition = false;

                    if (grounds[0].contactPoint.point.x < _unit.transform.position.x)
                    {
                        if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false))
                        {
                            makeTransition = true;
                        }
                    }
                    else if (grounds[0].contactPoint.point.x > _unit.transform.position.x)
                    {
                        if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false))
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