using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "SpriteAnimationSpec", menuName = "InfiniteRunner/SpriteAnimationSpec/SpriteAnimationSpec")]
    public class SpriteAnimationSpec : ScriptableObject
    {
        public string spriteName;
        public int spriteInterval;
        public Vector2 spriteSize;
        public OffsetType offsetType;
        public Vector2 additionalOffset;
    }
}