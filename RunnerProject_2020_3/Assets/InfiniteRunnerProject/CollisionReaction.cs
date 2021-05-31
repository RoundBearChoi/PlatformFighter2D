using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CollisionReaction
    {
        private UnitData _unitData = null;

        public CollisionReaction(UnitData unitData)
        {
            _unitData = unitData;
        }

        public CollisionReactionData GetReactionData()
        {
            foreach (CollisionData data in _unitData.listCollisionData)
            {
                Unit collidingUnit = data.collidingObject.GetComponent<Unit>();

                if (collidingUnit != null)
                {
                    //take damage
                    foreach (CollisionType danger in collidingUnit.listDangerousSides)
                    {
                        if (danger == CollisionType.LEFT && data.collisionType == CollisionType.RIGHT)
                        {
                            return new CollisionReactionData(CollisionReactionType.TAKE_DAMAGE, collidingUnit);
                        }
                    }

                    //deal damage to unit that is stepped on
                    if (data.collisionType == CollisionType.BOTTOM)
                    {
                        if (!collidingUnit.listDangerousSides.Contains(CollisionType.TOP))
                        {
                            return new CollisionReactionData(CollisionReactionType.DEAL_DAMAGE, collidingUnit);
                        }
                    }
                }

                //update on new ground
                Ground ground = data.collidingObject.GetComponent<Ground>();

                if (ground != null)
                {
                    if (data.collisionType == CollisionType.BOTTOM)
                    {
                        Debugger.Log("bottom collision detected");

                        if (ground != _unitData.currentGround)
                        {
                            _unitData.currentGround = ground;
                            return new CollisionReactionData(CollisionReactionType.GROUND_LAND, null);
                        }
                    }
                }
            }

            return new CollisionReactionData(CollisionReactionType.NONE, null);
        }
    }
}