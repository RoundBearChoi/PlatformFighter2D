using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct SpriteAnimationSpecs
    {
        public SpriteAnimationSpecs(string fileName, uint renderInterval, Vector2 pixelSize, OffsetType offsetType)
        {
            mSheetFileName = fileName;
            mRenderInterval = renderInterval;
            mPixelSize = pixelSize;
            mOffsetType = offsetType;
        }

        public string mSheetFileName;
        public uint mRenderInterval;
        public Vector2 mPixelSize;
        public OffsetType mOffsetType;
    }
}