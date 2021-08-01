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
            List<Ground> grounds = _unit.unitData.collisionStays.GetSideTouchingGrounds();

            //List<CollisionData> listData = _unit.unitData.collisionStays.GetSideCollisionData();
            //List<Ground> contactingGrounds = new List<Ground>();
            //
            ////temp (needs more conditions)
            //foreach(CollisionData c in listData)
            //{
            //    Ground ground = c.collidingObject.GetComponent<Ground>();
            //
            //    if (ground != null)
            //    {
            //        contactingGrounds.Add(ground);
            //    }
            //}

            if (grounds.Count >= 2)
            {
                _unit.unitData.listNextStates.Add(new LittleRed_WallSlide(_unit));
            }
        }
    }
}