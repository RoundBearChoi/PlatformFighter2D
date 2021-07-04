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

        public StandardInterval mStandardInterval = null;

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

                    if (spriteAni != _currentAnimation)
                    {
                        _currentAnimation = spriteAni;
                        _currentAnimation.ResetSpriteIndex();
                    }
                }
                else
                {
                    spriteAni.gameObject.SetActive(false);
                }
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

            if (_currentAnimation != null)
            {
                _currentAnimation.UpdateSpriteIndex(mStandardInterval);
            }
        }
    }
}