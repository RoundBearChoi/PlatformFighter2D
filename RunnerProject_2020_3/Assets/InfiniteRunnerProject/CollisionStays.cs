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

        public List<Unit> GetTouchingUnits()
        {
            List<Unit> touchingUnits = new List<Unit>();

            foreach (CollisionData data in _listCollisionStays)
            {
                Unit unit = data.collidingObject.GetComponent<Unit>();

                if (unit != null)
                {
                    touchingUnits.Add(unit);
                }
            }

            return touchingUnits;
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

        public List<CollisionData> GetSideCollisionData()
        {
            List<CollisionData> listCollisionData = new List<CollisionData>();

            foreach (CollisionData data in _listCollisionStays)
            {
                if (data.collisionType == CollisionType.LEFT || data.collisionType == CollisionType.RIGHT)
                {
                    listCollisionData.Add(data);
                }
            }

            return listCollisionData;
        }

        public bool IsOnFlatGround()
        {
            List<Ground> listGrounds = GetTouchingGrounds();

            if (listGrounds.Count == 0)
            {
                return false;
            }

            foreach (Ground ground in listGrounds)
            {
                if (Mathf.Abs(ground.transform.rotation.z) >= 0.001f)
                {
                    return false;
                }
            }

            return true;
        }
    }
}