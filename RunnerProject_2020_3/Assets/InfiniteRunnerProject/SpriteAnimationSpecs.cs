using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct SpriteAnimationSpecs
    {
        public SpriteAnimationSpecs(string fileName, uint interval, Vector2 size, OffsetType offset)
        {
            SheetFileName = fileName;
            renderInterval = interval;
            pixelSize = size;
            offsetType = offset;
        }

        public string SheetFileName;
        public uint renderInterval;
        public Vector2 pixelSize;
        public OffsetType offsetType;
    }
}