using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CollisionBehavior
    {
        private UnitData _unitData = null;

        public CollisionBehavior(UnitData unitData)
        {
            _unitData = unitData;
        }

        public CollisionReaction GetReactionData()
        {
            CollisionReaction takeDamage = new CollisionReaction(CollisionReactionType.NONE, null);
            CollisionReaction dealDamage = new CollisionReaction(CollisionReactionType.NONE, null);

            foreach (CollisionData data in _unitData.listCollisionEnters)
            {
                if (data.collidingObject == null)
                {
                    Debugger.Log("colliding obj is null");
                    continue;
                }

                Unit collidingUnit = data.collidingObject.GetComponent<Unit>();

                if (collidingUnit != null)
                {
                    //take damage
                    if (collidingUnit.attackData.IsAttackingSide(CollisionType.LEFT) && data.collisionType == CollisionType.RIGHT)
                    {
                        takeDamage.reactionType = CollisionReactionType.TAKE_DAMAGE;
                        takeDamage.collidingUnit = collidingUnit;
                    }

                    //deal damage to unit that is stepped on
                    if (!collidingUnit.attackData.IsAttackingSide(CollisionType.TOP))
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