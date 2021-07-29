using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public struct OverlapBoxBounds
    {
        public OverlapBoxBounds(Vector2 relativePoint, Vector2 size, float angle)
        {
            mRelativePoint = relativePoint;
            mSize = size;
            mAngle = angle;
    }

        public Vector2 mRelativePoint;
        public Vector2 mSize;
        public float mAngle;
    }
}