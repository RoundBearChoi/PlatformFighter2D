using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RB
{
    [CreateAssetMenu(fileName = "SpriteAnimationSpec", menuName = "InfiniteRunner/SpriteAnimationSpec/SpriteAnimationSpec")]
    public class SpriteAnimationSpec : ScriptableObject
    {
        public List<string> listSpriteNames = new List<string>();

        [Space(5)]

        public string backupSpriteName;
        
        [Space(10)]
                
        public uint spriteInterval;
        public Vector2 spriteSize;
        public OffsetType offsetType;
        public Vector2 additionalOffset;
        public bool playOnce;

        [Space(10)]
        public SpriteType spriteType;

        [Space(10)]
        public uint tiling;
    }
}