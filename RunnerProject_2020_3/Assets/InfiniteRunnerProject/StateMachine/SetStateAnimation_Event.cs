using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RB
{
    [System.Serializable]
    public class SetStateAnimation_Event : UnityEvent
    {
        public SpriteAnimationSpec targetSpec = null;
    }
}