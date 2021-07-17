using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteStage : Stage
    {
        SpriteAnimations _dummyAnimation;
        GameObject _dummyObj;

        [SerializeField]
        SpriteAnimationSpec animationSpec = null;

        [SerializeField]
        OverlapBoxCollisionData _dummyOverlapBoxCollisionData;

        [SerializeField]
        int _collisionDataIndex;

        [SerializeField]
        GameObject basicRedPrefab;

        public override void Init()
        {
            _userInput = new UserInput();

            _dummyObj = new GameObject();
            _dummyObj.transform.parent = this.transform;
            _dummyObj.transform.position = Vector3.zero;
            _dummyObj.transform.rotation = Quaternion.identity;
            _dummyObj.name = "dummy animation";

            GameObject red = Instantiate(basicRedPrefab);
            red.transform.parent = _dummyObj.transform;
            red.transform.localPosition = Vector3.zero;
            red.transform.localRotation = Quaternion.identity;

            _dummyAnimation = new SpriteAnimations(null);
            _dummyAnimation.AddSpriteAnimation(animationSpec, _dummyObj.transform);
            _dummyAnimation.currentAnimation = _dummyAnimation.GetLastSpriteAnimation();
            _dummyAnimation.ManualSetSpriteIndex(0);
            _dummyAnimation.currentAnimation.UpdateSpriteOnIndex();
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f6Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }
        }

        public override void OnFixedUpdate()
        {
            if (_userInput.ContainsKeyPress(UserInput.keyboard.spaceKey))
            {
                _dummyAnimation.ManualSetSpriteIndex(_dummyAnimation.currentAnimation.SPRITE_INDEX + 1);

                if (_dummyAnimation.currentAnimation.SPRITE_INDEX >= _dummyAnimation.currentAnimation.SPRITES_COUNT)
                {
                    _dummyAnimation.ManualSetSpriteIndex(0);
                }

                _dummyAnimation.currentAnimation.UpdateSpriteOnIndex();
            }

            if (_collisionDataIndex < _dummyOverlapBoxCollisionData.listSpecs.Count)
            {
                OverlapBoxCollisionSpecs specs = _dummyOverlapBoxCollisionData.listSpecs[_collisionDataIndex];

                foreach(OverlapBoxBounds bounds in specs.mlistBounds)
                {
                    Vector2 centerPoint = new Vector2(bounds.mRelativePoint.x, bounds.mRelativePoint.y);
                    BoxCalculator.GetCollisionResults(centerPoint, bounds, specs.mContactFilter2D, 0f);
                }
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();
        }

        public override void OnLateUpdate()
        {

        }
    }
}