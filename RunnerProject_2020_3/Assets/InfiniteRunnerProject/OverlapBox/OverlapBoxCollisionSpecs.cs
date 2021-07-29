using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public struct OverlapBoxCollisionSpecs
    {
        public OverlapBoxCollisionSpecs(int targetSpriteIndex, int maxHits, uint stopFrames, List<OverlapBoxBounds> listBounds, ContactFilter2D contactFilter)
        {
            mTargetSpriteIndex = targetSpriteIndex;
            mMaxHits = maxHits;
            mStopFrames = stopFrames;
            mContactFilter2D = contactFilter;
            mlistBounds = listBounds;
        }

        public int mTargetSpriteIndex;
        public int mMaxHits;
        public uint mStopFrames;
        public ContactFilter2D mContactFilter2D;
        public List<OverlapBoxBounds> mlistBounds;
    }
}