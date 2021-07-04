using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct SpriteAnimationSpecs
    {
        public SpriteAnimationSpecs(string fileName, Vector2 pixelSize, OffsetType offsetType, Vector2 additionalOffset)
        {
            mSheetFileName = fileName;
            mPixelSize = pixelSize;
            mOffsetType = offsetType;
            mAdditionalOffset = additionalOffset;
        }

        public string mSheetFileName;
        public Vector2 mPixelSize;
        public OffsetType mOffsetType;
        public Vector2 mAdditionalOffset;
    }
}