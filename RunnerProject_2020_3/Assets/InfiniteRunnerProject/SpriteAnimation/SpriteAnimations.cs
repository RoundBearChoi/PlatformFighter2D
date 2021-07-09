using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimations
    {
        private List<SpriteAnimation> _listSpriteAnimations = null;
        private IStateController _IStateController = null;

        public SpriteAnimation currentAnimation = null;

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
                    if (currentAnimation != spriteAni)
                    {
                        spriteAni.gameObject.SetActive(true);
                        currentAnimation = spriteAni;
                        currentAnimation.ResetSpriteIndex();
                    }
                }
                else
                {
                    spriteAni.gameObject.SetActive(false);
                }
            }
        }

        //old
        public void AddSpriteAnimation(string objName, SpriteAnimationSpecs specs, Transform parent)
        {
            GameObject obj = new GameObject(objName);
            obj.transform.parent = parent;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            _listSpriteAnimations.Add(obj.AddComponent<SpriteAnimation>());
            _listSpriteAnimations[_listSpriteAnimations.Count - 1].Init(specs);
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

        public void OnFixedUpdate()
        {
            foreach(SpriteAnimation spriteAnimation in _listSpriteAnimations)
            {
                if (!spriteAnimation.ProcessingAdditionalInterval())
                {
                    spriteAnimation.UpdateSpriteIndex();
                }

                spriteAnimation.UpdateSpriteOnIndex();
            }
        }
    }
}