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
            for (int i = 0; i < _listSpriteAnimations.Count; i++)
            {
                int n = _listSpriteAnimations[i].animationHash.CompareTo(_IStateController.GetAnimationHash());

                if (n == 0)
                {
                    _listSpriteAnimations[i].gameObject.SetActive(true);

                    if (_listSpriteAnimations[i] != _currentAnimation)
                    {
                        _currentAnimation = _listSpriteAnimations[i];
                        _currentAnimation.ResetSpriteIndex();
                    }
                }
                else
                {
                    _listSpriteAnimations[i].gameObject.SetActive(false);
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
            if (_currentAnimation != null)
            {
                AdditionalInterval additionalInterval = _currentAnimation.GetAdditionalInterval();

                if (additionalInterval != null)
                {
                    additionalInterval.UpdateInterval();
                }
                else
                {
                    //_currentAnimation.mAdditionalIntervals.ResetCount();
                    _currentAnimation.mStandardInterval.UpdateInterval();
                    _currentAnimation.UpdateSpriteIndex();
                }
            }
        }
    }
}