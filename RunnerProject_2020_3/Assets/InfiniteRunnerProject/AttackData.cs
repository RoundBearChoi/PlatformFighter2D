using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AttackData
    {
        private List<CollisionType> _listAttackingSides = new List<CollisionType>();

        public void AddAttackingSide(CollisionType collisionType)
        {
            _listAttackingSides.Add(collisionType);
        }

        public bool IsAttackingSide(CollisionType collisionType)
        {
            if (_listAttackingSides.Contains(collisionType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}