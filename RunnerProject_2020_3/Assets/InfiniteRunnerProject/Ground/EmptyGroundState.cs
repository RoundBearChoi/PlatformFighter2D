using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class EmptyGroundState : UnitState
    {
        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return null;
        }
    }
}