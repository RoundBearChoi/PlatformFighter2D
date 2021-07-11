using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct OverlapBoxSpecs
    {
        public OverlapBoxSpecs(int targetSpriteIndex, int maxHits, uint stopFrames, OverlapBoxBounds boxBounds, ContactFilter2D contactFilter)
        {
            mMaxHits = maxHits;
            mStopFrames = stopFrames;
            mBoxBounds = boxBounds;
            mContactFilter2D = contactFilter;
            mTargetSpriteIndex = targetSpriteIndex;
        }

        public int mTargetSpriteIndex;
        public int mMaxHits;
        public uint mStopFrames;
        public OverlapBoxBounds mBoxBounds;
        public ContactFilter2D mContactFilter2D;
    }
}