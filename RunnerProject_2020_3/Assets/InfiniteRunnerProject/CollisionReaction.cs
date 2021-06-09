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

            foreach (CollisionData data in _unitData.listCollisionEnters)
            {
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

            //clear collisiondata in the end
            _unitData.listCollisionEnters.Clear();

            if (takeDamage.reactionType == CollisionReactionType.TAKE_DAMAGE)
            {
                return takeDamage;
            }
            else if (dealDamage.reactionType == CollisionReactionType.DEAL_DAMAGE)
            {
                return dealDamage;
            }

            return new CollisionReactionData(CollisionReactionType.NONE, null);
        }
    }
}