using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimations
    {
        private List<SpriteAnimation> _listSpriteAnimations = null;
        private IStateController<UnitState> _IStateController = null;

        public SpriteAnimation currentAnimation = null;

        public SpriteAnimations(IStateController<UnitState> stateController)
        {
            _listSpriteAnimations = new List<SpriteAnimation>();
            _IStateController = stateController;
        }

        public void MatchAnimationToState()
        {
            foreach (SpriteAnimation spriteAni in _listSpriteAnimations)
            {
                if (spriteAni.animationSpec == _IStateController.GetCurrentState().GetSpriteAnimationSpec())
                {
                    if (currentAnimation != spriteAni)
                    {
                        spriteAni.gameObject.SetActive(true);
                        currentAnimation = spriteAni;
                        currentAnimation.ResetSpriteIndex();

                        //updating on new state & reset
                        currentAnimation.UpdateSpriteOnIndex();
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
                if (!spriteAnimation.ProcessingAdditionalInterval())
                {
                    spriteAnimation.UpdateSpriteIndex();
                }

                spriteAnimation.UpdateSpriteOnIndex();
            }
        }

        public void ManualSetSpriteIndex(int index)
        {
            currentAnimation.ManualSetSpriteIndex(index);
        }
    }
}