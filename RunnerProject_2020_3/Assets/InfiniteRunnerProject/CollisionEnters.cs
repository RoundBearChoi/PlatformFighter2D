using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CollisionEnters
    {
        private List<CollisionData> _listCollisionEnters = new List<CollisionData>();

        public void Clear()
        {
            _listCollisionEnters.Clear();
        }

        public void Add(CollisionData collisionData)
        {
            _listCollisionEnters.Add(collisionData);
        }

        public CollisionReaction GetReactionData()
        {
            CollisionReaction takeDamage = new CollisionReaction(CollisionReactionType.NONE, null);
            CollisionReaction dealDamage = new CollisionReaction(CollisionReactionType.NONE, null);

            foreach (CollisionData data in _listCollisionEnters)
            {
                if (data.collidingObject == null)
                {
                    Debugger.Log("colliding obj is null");
                    continue;
                }

                Unit collidingUnit = data.collidingObject.GetComponent<Unit>();

                //ground is also unit (should find a better way to differenciate)
                if (collidingUnit != null && collidingUnit is Ground == false)
                {
                    //take damage
                    if (collidingUnit.attackData.IsAttackingSide(CollisionType.LEFT) && data.collisionType == CollisionType.RIGHT)
                    {
                        takeDamage.reactionType = CollisionReactionType.TAKE_DAMAGE;
                        takeDamage.collidingUnit = collidingUnit;
                    }

                    //deal damage to unit that is stepped on
                    if (!collidingUnit.attackData.IsAttackingSide(CollisionType.TOP) && data.collisionType == CollisionType.BOTTOM)
                    {
                        dealDamage.reactionType = CollisionReactionType.DEAL_DAMAGE;
                        dealDamage.collidingUnit = collidingUnit;
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

            return new CollisionReaction(CollisionReactionType.NONE, null);
        }
    }
}