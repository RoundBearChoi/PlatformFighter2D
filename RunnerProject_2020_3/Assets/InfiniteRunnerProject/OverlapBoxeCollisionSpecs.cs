using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct OverlapBoxeCollisionSpecs
    {
        public OverlapBoxeCollisionSpecs(int targetSpriteIndex, int maxHits, uint stopFrames, List<OverlapBoxBounds> listBounds, ContactFilter2D contactFilter)
        {
            mMaxHits = maxHits;
            mStopFrames = stopFrames;
            mlistBounds = listBounds;
            mContactFilter2D = contactFilter;
            mTargetSpriteIndex = targetSpriteIndex;
        }

        public int mTargetSpriteIndex;
        public int mMaxHits;
        public uint mStopFrames;
        public List<OverlapBoxBounds> mlistBounds;
        public ContactFilter2D mContactFilter2D;
    }
}