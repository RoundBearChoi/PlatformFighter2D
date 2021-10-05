using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface ISpriteAnimations
    {
        public SpriteAnimation GetCurrentAnimation();
        public void SetCurrentAnimation(SpriteAnimation animation);

        public void OnUpdate();
        public void OnFixedUpdate();
                
        public void MatchAnimationToState();
        public GameObject AddSpriteAnimation(UnitCreationSpec creationSpec, SpriteAnimationSpec spriteSpec, Transform parent);
        public SpriteAnimation GetLastSpriteAnimation();
        public void ManualSetSpriteIndex(int index);
    }
}