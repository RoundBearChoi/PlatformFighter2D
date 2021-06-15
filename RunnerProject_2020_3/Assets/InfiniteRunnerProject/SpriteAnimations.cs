using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimations
    {
        private List<SpriteAnimation> _listSpriteAnimations = null;
        private StateController _stateController = null;

        public SpriteAnimations(StateController stateController)
        {
            _listSpriteAnimations = new List<SpriteAnimation>();
            _stateController = stateController;
            _stateController.spriteAnimations = this;
        }

        public void MatchAnimationToState()
        {
            foreach (SpriteAnimation spriteAni in _listSpriteAnimations)
            {
                int n = spriteAni.animationHash.CompareTo(_stateController.currentState.GetAnimationHash());

                if (n == 0)
                {
                    spriteAni.gameObject.SetActive(true);
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

        public void Add(string objName, SpriteAnimationSpecs specs, Transform parent)
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
            foreach(SpriteAnimation spriteAnimation in _listSpriteAnimations)
            {
                spriteAnimation.OnFixedUpdate();
            }
        }
    }
}