using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RB
{
    [CreateAssetMenu(fileName = "SpriteAnimationSpec", menuName = "InfiniteRunner/SpriteAnimationSpec/SpriteAnimationSpec")]
    public class SpriteAnimationSpec : ScriptableObject
    {
        public string spriteName;
        public string backupSpriteName;
        public List<string> listSpriteNames = new List<string>();

        [Space(10)]
                
        public uint spriteInterval;
        public Vector2 spriteSize;
        public OffsetType offsetType;
        public Vector2 additionalOffset;
        public bool playOnce;

        [Space(10)]
        public SetStateAnimation_Event setCorrespondingState;
    }
}