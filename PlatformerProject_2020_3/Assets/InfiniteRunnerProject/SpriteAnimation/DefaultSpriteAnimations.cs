using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultSpriteAnimations : ISpriteAnimations
    {
        private Unit _unit = null;
        private List<SpriteAnimation> _listSpriteAnimations = null;
        private IStateController<UnitState> _IStateController = null;

        private SpriteAnimation _currentAnimation = null;

        public DefaultSpriteAnimations(IStateController<UnitState> stateController, Unit unit)
        {
            _unit = unit;
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
                if (_IStateController.GetCurrentState().IsMatching(spriteAni.ANIMATION_SPEC.spriteType))
                {
                    if (_currentAnimation != spriteAni)
                    {
                        spriteAni.gameObject.SetActive(true);
                        _currentAnimation = spriteAni;
                        _currentAnimation.ResetSpriteIndex();

                        //updating on new state & reset
                        _currentAnimation.UpdateSpriteOnIndex();

                        //sync with clients
                        if (_unit.unitType == UnitType.LITTLE_RED_LIGHT ||
                            _unit.unitType == UnitType.LITTLE_RED_DARK)
                        {
                            if (RB.Server.ServerControl.CURRENT != null)
                            {
                                RB.Server.ServerControl.CURRENT.serverSend.SendPlayerSpriteType(_unit.clientIndex, _currentAnimation.spriteType);
                            }
                        }
                    }
                }
                else
                {
                    spriteAni.gameObject.SetActive(false);
                }
            }
        }

        public void AddSpriteAnimation(UnitCreationSpec creationSpec, SpriteAnimationSpec spriteSpec, Transform parent)
        {
            int index = 0;

            if (creationSpec != null)
            {
                index = creationSpec.SpriteNameIndex;
            }

            if (index >= spriteSpec.listSpriteNames.Count)
            {
                index = spriteSpec.listSpriteNames.Count - 1;
            }

            string name = spriteSpec.listSpriteNames[index];

            GameObject obj = new GameObject(name);
            obj.transform.parent = parent;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            _listSpriteAnimations.Add(obj.AddComponent<SpriteAnimation>());

            _listSpriteAnimations[_listSpriteAnimations.Count - 1].spriteType = spriteSpec.spriteType;
            _listSpriteAnimations[_listSpriteAnimations.Count - 1].SetSpriteAnimationSpec(spriteSpec);
            _listSpriteAnimations[_listSpriteAnimations.Count - 1].LoadSprite(creationSpec);
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