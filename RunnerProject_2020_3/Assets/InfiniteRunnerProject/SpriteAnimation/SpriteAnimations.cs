using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimations
    {
        private List<SpriteAnimation> _listSpriteAnimations = null;
        private IStateController _IStateController = null;
        private SpriteAnimation _currentAnimation = null;

        public StandardIntervalCounter mStandardInterval = null;

        public SpriteAnimation CURRENT_SPRITEANIMATION
        {
            get
            {
                return _currentAnimation;
            }
        }

        public SpriteAnimations(IStateController stateController)
        {
            _listSpriteAnimations = new List<SpriteAnimation>();
            _IStateController = stateController;

            if (_IStateController != null)
            {
                _IStateController.SetSpriteAnimations(this);
            }
        }

        public void MatchAnimationToState()
        {
            foreach (SpriteAnimation spriteAni in _listSpriteAnimations)
            {
                int n = spriteAni.animationHash.CompareTo(_IStateController.GetAnimationHash());

                if (n == 0)
                {
                    spriteAni.gameObject.SetActive(true);
                    _currentAnimation = spriteAni;
                }
                else
                {
                    spriteAni.gameObject.SetActive(false);
                }
            }
        }

        public void ResetSpriteIndexes()
        {
            foreach(SpriteAnimation spriteAnimation in _listSpriteAnimations)
            {
                spriteAnimation.Reset();
            }
        }

        public void AddSpriteAnimation(string objName, SpriteAnimationSpecs specs, Transform parent)
        {
            GameObject obj = new GameObject(objName);
            obj.transform.parent = parent;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            _listSpriteAnimations.Add(obj.AddComponent<SpriteAnimation>());
            _listSpriteAnimations[_listSpriteAnimations.Count - 1].Init(specs);
        }

        public SpriteAnimation GetLastSpriteAnimation()
        {
            return _listSpriteAnimations[_listSpriteAnimations.Count - 1];
        }

        public void OnFixedUpdate()
        {
            mStandardInterval.UpdateInterval();

            foreach(SpriteAnimation spriteAnimation in _listSpriteAnimations)
            {
                spriteAnimation.UpdateSpriteIndex(mStandardInterval);
            }
        }
    }
}