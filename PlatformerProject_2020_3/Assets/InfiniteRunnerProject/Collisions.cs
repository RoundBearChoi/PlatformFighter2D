using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class Collisions
    {
        protected List<CollisionData> _listCollisionData = new List<CollisionData>();

        public virtual void AddCollisionData(CollisionData data)
        {
            _listCollisionData.Add(data);
        }

        public virtual void ClearList()
        {
            _listCollisionData.Clear();
        }

        public virtual int GetCount()
        {
            return _listCollisionData.Count;
        }

        public virtual List<CollisionData> GetCollisionData(CollisionType collisionType)
        {
            List<CollisionData> listCollisionData = new List<CollisionData>();

            foreach (CollisionData data in _listCollisionData)
            {
                if (data.collisionType == collisionType)
                {
                    listCollisionData.Add(data);
                }
            }

            return listCollisionData;
        }

        public virtual bool IsTouchingGround(CollisionType collisionType)
        {
            foreach (CollisionData data in _listCollisionData)
            {
                if (data.collisionType == collisionType)
                {
                    Ground ground = data.collidingObject.GetComponent<Ground>();

                    if (ground != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public virtual bool IsOnFlatGround()
        {
            List<Ground> touchingGrounds = new List<Ground>();

            foreach (CollisionData data in _listCollisionData)
            {
                Ground ground = data.collidingObject.GetComponent<Ground>();

                if (ground != null)
                {
                    touchingGrounds.Add(ground);
                }
            }

            if (touchingGrounds.Count == 0)
            {
                return false;
            }

            foreach (Ground ground in touchingGrounds)
            {
                if (Mathf.Abs(ground.transform.rotation.z) >= 0.001f)
                {
                    return false;
                }
            }

            return true;
        }

        public virtual List<CollisionData> GetSideTouchingGrounds()
        {
            List<CollisionData> listData = GetSideCollisionData();
            List<CollisionData> contactingGrounds = new List<CollisionData>();

            //temp (needs more conditions)
            foreach (CollisionData c in listData)
            {
                Ground ground = c.collidingObject.GetComponent<Ground>();

                if (ground != null)
                {
                    contactingGrounds.Add(c);
                }
            }

            return contactingGrounds;
        }

        public virtual List<Ground> GetTouchingGrounds(CollisionType collisionType)
        {
            List<Ground> touchingGrounds = new List<Ground>();

            foreach (CollisionData data in _listCollisionData)
            {
                if (data.collisionType == collisionType)
                {
                    Ground ground = data.collidingObject.GetComponent<Ground>();

                    if (ground != null)
                    {
                        touchingGrounds.Add(ground);
                    }
                }
            }

            return touchingGrounds;
        }

        public virtual List<CollisionData> GetSideCollisionData()
        {
            List<CollisionData> listCollisionData = new List<CollisionData>();

            foreach (CollisionData data in _listCollisionData)
            {
                if (data.collisionType == CollisionType.LEFT || data.collisionType == CollisionType.RIGHT)
                {
                    listCollisionData.Add(data);
                }
            }

            return listCollisionData;
        }
    }
}