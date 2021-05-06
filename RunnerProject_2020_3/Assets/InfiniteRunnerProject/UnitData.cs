using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitData
    {
        public UnitData(Transform transform)
        {
            unitTransform = transform;
        }

        public float horizontalVelocity = 0f;
        public float verticalVelocity = 0f;
        public Transform unitTransform = null;
    }
}