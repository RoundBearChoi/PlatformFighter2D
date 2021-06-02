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
            CollisionReactionData takeDamage = new CollisionReactionData(CollisionReactionType.NONE, null);
            CollisionReactionData dealDamage = new CollisionReactionData(CollisionReactionType.NONE, null);
            CollisionReactionData groundHit = new CollisionReactionData(CollisionReactionType.NONE, null);

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
                            takeDamage.reactionType = CollisionReactionType.TAKE_DAMAGE;
                            takeDamage.collidingUnit = collidingUnit;
                        }
                    }

                    //deal damage to unit that is stepped on
                    if (data.collisionType == CollisionType.BOTTOM)
                    {
                        if (!collidingUnit.listDangerousSides.Contains(CollisionType.TOP))
                        {
                            dealDamage.reactionType = CollisionReactionType.DEAL_DAMAGE;
                            dealDamage.collidingUnit = collidingUnit;
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
                            Debug.DrawLine(_unitData.boxCollider2D.bounds.center, data.collidingObject.transform.position, Color.yellow, 3f);
                            groundHit.reactionType = CollisionReactionType.GROUND_LAND;
                            groundHit.collidingUnit = collidingUnit;
                            _unitData.currentGround = ground;
                        }
                    }
                }
            }

            if (takeDamage.reactionType == CollisionReactionType.TAKE_DAMAGE)
            {
                return takeDamage;
            }
            else if (dealDamage.reactionType == CollisionReactionType.DEAL_DAMAGE)
            {
                return dealDamage;
            }
            else if (groundHit.reactionType == CollisionReactionType.GROUND_LAND)
            {
                return groundHit;
            }

            return new CollisionReactionData(CollisionReactionType.NONE, null);
        }
    }
}