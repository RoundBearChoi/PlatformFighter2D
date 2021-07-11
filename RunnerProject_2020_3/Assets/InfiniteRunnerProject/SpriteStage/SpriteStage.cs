using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteStage : Stage
    {
        SpriteAnimations _dummyAnimation;
        GameObject _dummyObj;
        UserInput _userInput = new UserInput();

        [SerializeField]
        Vector2 overlapBoxPoint = new Vector2();

        [SerializeField]
        Vector2 overlapBoxSize = new Vector2();

        [SerializeField]
        GameObject basicRedPrefab;

        [SerializeField]
        SpriteAnimationSpec animationSpec = null;

        public override void Init()
        {
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
                _gameIntializer.listStageTransitions.Add(new IntroStageTransition(_gameIntializer));
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

            ContactFilter2D contactFilter = new ContactFilter2D();
            OverlapBoxBounds boxBounds = new OverlapBoxBounds(overlapBoxPoint, overlapBoxSize, 0f);
            OverlapBoxSpecs specs = new OverlapBoxSpecs(0, 0, 0, boxBounds, contactFilter);
            BoxCalculator.GetCollisionResults(overlapBoxPoint, specs, 0f);

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();
        }

        public override void OnLateUpdate()
        {

        }
    }
}