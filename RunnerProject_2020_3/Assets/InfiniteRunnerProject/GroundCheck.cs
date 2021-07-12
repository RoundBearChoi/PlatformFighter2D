using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class GroundCheck
    {
        public static bool IsOnFlatGround(CollisionStays collisionStays)
        {
            List<Ground> listGrounds = collisionStays.GetTouchingGrounds();

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