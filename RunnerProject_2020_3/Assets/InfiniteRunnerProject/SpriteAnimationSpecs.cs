using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct SpriteAnimationSpecs
    {
        public SpriteAnimationSpecs(uint interval, Vector2 size, OffsetType offset)
        {
            renderInterval = interval;
            pixelSize = size;
            offsetType = offset;
        }

        public uint renderInterval;
        public Vector2 pixelSize;
        public OffsetType offsetType;
    }
}