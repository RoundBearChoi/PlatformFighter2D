using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultSpriteAnimations : ISpriteAnimations
    {
        private List<SpriteAnimation> _listSpriteAnimations = null;
        private IStateController<UnitState> _IStateController = null;

        private SpriteAnimation _currentAnimation = null;

        public DefaultSpriteAnimations(IStateController<UnitState> stateController)
        {
            _listSpriteAnimations = new List<SpriteAnimation>();
            _IStateController = stateController;
        }

        public SpriteAnimation GetCurrentAnimation()
        {
            return _currentAnimation;
        }

        public void SetCurrentAnimation(SpriteAnimation animation)
        {
            _currentAnimation = animation;
        }

        public void OnUpdate()
        {
            //matching state to sprites happens as often as possible (both in update and fixedupdate)
            MatchAnimationToState();
        }

        public void OnFixedUpdate()
        {
            MatchAnimationToState();

            foreach (SpriteAnimation spriteAnimation in _listSpriteAnimations)
            {
                spriteAnimation.UpdateSpriteIndex();
                spriteAnimation.UpdateSpriteOnIndex();
            }
        }

        public void MatchAnimationToState()
        {
            foreach (SpriteAnimation spriteAni in _listSpriteAnimations)
            {
                if (spriteAni.animationSpec == _IStateController.GetCurrentState().GetSpriteAnimationSpec())
                {
                    if (_currentAnimation != spriteAni)
                    {
                        spriteAni.gameObject.SetActive(true);
                        _currentAnimation = spriteAni;
                        _currentAnimation.ResetSpriteIndex();

                        //updating on new state & reset
                        _currentAnimation.UpdateSpriteOnIndex();
                    }
                }
                else
                {
                    spriteAni.gameObject.SetActive(false);
                }
            }
        }

        public void AddSpriteAnimation(SpriteAnimationSpec spec, Transform parent)
        {
            //instantiate prefab
            GameObject obj = new GameObject(spec.spriteName);
            obj.transform.parent = parent;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            _listSpriteAnimations.Add(obj.AddComponent<SpriteAnimation>());

            _listSpriteAnimations[_listSpriteAnimations.Count - 1].Init(spec);
        }

        public SpriteAnimation GetLastSpriteAnimation()
        {
            return _listSpriteAnimations[_listSpriteAnimations.Count - 1];
        }

        public void ManualSetSpriteIndex(int index)
        {
            _currentAnimation.ManualSetSpriteIndex(index);
        }
    }
}