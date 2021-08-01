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
            List<CollisionData> listData = _unit.unitData.collisionStays.GetSideCollisionData();
            List<Ground> contactingGrounds = new List<Ground>();

            //temp (needs more conditions)
            foreach(CollisionData c in listData)
            {
                if (c.contactPoint.normal.y == 0f)
                {
                    Ground ground = c.collidingObject.GetComponent<Ground>();

                    if (ground != null)
                    {
                        contactingGrounds.Add(ground);
                    }
                }
            }

            if (contactingGrounds.Count >= 2)
            {
                _unit.unitData.listNextStates.Add(new LittleRed_WallSlide(_unit));
            }
        }
    }
}