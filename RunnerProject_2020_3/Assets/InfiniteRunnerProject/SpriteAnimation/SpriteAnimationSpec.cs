using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "SpriteAnimationSpec", menuName = "InfiniteRunner/SpriteAnimationSpec/SpriteAnimationSpec")]
    public class SpriteAnimationSpec : ScriptableObject
    {
        public string spriteName;
        public uint spriteInterval;
        public Vector2 spriteSize;
        public OffsetType offsetType;
        public Vector2 additionalOffset;
        public List<AdditionalInterval> additionalIntervals = new List<AdditionalInterval>();
        public bool playOnce;
    }
}