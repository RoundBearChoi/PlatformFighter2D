using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpritesStage : Stage
    {
        SpriteAnimations _punchAnimations;
        GameObject _dummyObj;
        UserInput _userInput = new UserInput();

        [SerializeField]
        GameObject basicRedPrefab;

        public override void Init()
        {
            _dummyObj = new GameObject();
            _dummyObj.transform.parent = this.transform;
            _dummyObj.transform.position = Vector3.zero;
            _dummyObj.transform.rotation = Quaternion.identity;
            _dummyObj.name = "dummy punch animation obj";

            GameObject red = Instantiate(basicRedPrefab);
            red.transform.parent = _dummyObj.transform;
            red.transform.localPosition = Vector3.zero;
            red.transform.localRotation = Quaternion.identity;

            _punchAnimations = new SpriteAnimations(null);

            _punchAnimations.AddSpriteAnimation(
                "runner straight punch animation",
                new SpriteAnimationSpecs(
                    "Texture_StraightPunch",
                    StaticRefs.runnerSpriteData.StraightPunch_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    StaticRefs.runnerSpriteData.StraightPunch_AdditionalOffset),
                _dummyObj.transform);

            _punchAnimations.mStandardInterval = new StandardIntervalCounter(0);

            _punchAnimations.OnFixedUpdate();
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
                _punchAnimations.OnFixedUpdate();
                _punchAnimations.GetLastSpriteAnimation().UpdateCurrentSprite();
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();
        }

        public override void OnLateUpdate()
        {

        }
    }
}