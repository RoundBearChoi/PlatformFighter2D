using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct SpriteAnimationSpecs
    {
        public SpriteAnimationSpecs(string fileName, uint renderInterval, Vector2 pixelSize, OffsetType offsetType, Vector2 additionalOffset)
        {
            mSheetFileName = fileName;
            mRenderInterval = renderInterval;
            mPixelSize = pixelSize;
            mOffsetType = offsetType;
            mAdditionalOffset = additionalOffset;
        }

        public string mSheetFileName;
        public uint mRenderInterval;
        public Vector2 mPixelSize;
        public OffsetType mOffsetType;
        public Vector2 mAdditionalOffset;
    }
}