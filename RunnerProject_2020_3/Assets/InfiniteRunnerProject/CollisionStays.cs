using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CollisionStays
    {
        private List<CollisionData> _listCollisionStays = new List<CollisionData>();

        public void Clear()
        {
            _listCollisionStays.Clear();
        }

        public void AddCollisionStay(CollisionData data)
        {
            _listCollisionStays.Add(data);
        }

        public int GetCount()
        {
            return _listCollisionStays.Count;
        }

        public List<Ground> GetTouchingGrounds()
        {
            List<Ground> touchingGrounds = new List<Ground>();

            foreach (CollisionData data in _listCollisionStays)
            {
                Ground ground = data.collidingObject.GetComponent<Ground>();

                if (ground != null)
                {
                    touchingGrounds.Add(ground);
                }
            }

            return touchingGrounds;
        }

        public bool IsTouchingGround(CollisionType collisionType)
        {
            foreach (CollisionData data in _listCollisionStays)
            {
                if (data.collisionType == collisionType)
                {
                    if (data.collidingObject.GetComponent<Ground>() != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsTouchingSide()
        {
            foreach (CollisionData data in _listCollisionStays)
            {
                if (data.collisionType == CollisionType.LEFT || data.collisionType == CollisionType.RIGHT)
                {
                    return true;
                }
            }

            return false;
        }
    }
}