using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class EmptySpriteAnimations : ISpriteAnimations
    {
        public SpriteAnimation GetCurrentAnimation()
        {
            return null;
        }

        public void SetCurrentAnimation(SpriteAnimation animation)
        {

        }

        public void OnUpdate()
        {

        }

        public void OnFixedUpdate()
        {

        }

        public void MatchAnimationToState()
        {

        }

        public void AddSpriteAnimation(UnitCreationSpec creationSpec, SpriteAnimationSpec spriteSpec, Transform parent)
        {

        }

        public SpriteAnimation GetLastSpriteAnimation()
        {
            return null;
        }

        public void ManualSetSpriteIndex(int index)
        {

        }
    }
}