using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public struct PositionAndDirection
    {
        public PositionAndDirection(Vector3 pos, bool facingRight)
        {
            mPosition = pos;
            mFacingRight = facingRight;
        }

        public Vector3 mPosition;
        public bool mFacingRight;
    }
}