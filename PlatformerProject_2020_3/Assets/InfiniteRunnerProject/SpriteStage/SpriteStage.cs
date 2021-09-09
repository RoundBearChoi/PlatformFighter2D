using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteStage : BaseStage
    {
        DefaultSpriteAnimations _dummyAnimation;
        GameObject _dummyObj;

        [SerializeField]
        SpriteAnimationSpec animationSpec = null;
        SpriteAnimationSpec _prevSpec = null;

        [SerializeField]
        OverlapBoxCollisionData _dummyOverlapBoxCollisionData;

        [SerializeField]
        int _collisionDataIndex;

        [SerializeField]
        GameObject basicRedPrefab;

        public override void Init()
        {
            _inputController.AddInput();

            _dummyObj = new GameObject();
            _dummyObj.transform.parent = this.transform;
            _dummyObj.transform.position = Vector3.zero;
            _dummyObj.transform.rotation = Quaternion.identity;
            _dummyObj.name = "dummy animation";

            GameObject red = Instantiate(basicRedPrefab);
            red.transform.parent = _dummyObj.transform;
            red.transform.localPosition = Vector3.zero;
            red.transform.localRotation = Quaternion.identity;

            GameCamera gameCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.GAME_CAMERA)) as GameCamera;
            gameCamera.transform.parent = this.transform;
            gameCamera.transform.localPosition = new Vector3(0f, 3f, -5f);

            gameCamera.GetComponent<Camera>().orthographicSize = 6.5f;

            _dummyAnimation = new DefaultSpriteAnimations(null);
            _dummyAnimation.AddSpriteAnimation(null, animationSpec, _dummyObj.transform);
            _dummyAnimation.SetCurrentAnimation(_dummyAnimation.GetLastSpriteAnimation());
            _dummyAnimation.ManualSetSpriteIndex(0);
            _dummyAnimation.GetCurrentAnimation().UpdateSpriteOnIndex();

            _prevSpec = animationSpec;
        }

        public override void OnUpdate()
        {
            _inputController.GetUserInput(InputType.PLAYER_ONE).OnUpdate();

            if (_prevSpec != animationSpec)
            {
                Destroy(_dummyObj);
                _dummyObj = null;
                Init();
            }

            if (_inputController.GetUserInput(InputType.PLAYER_ONE).commands.ContainsPress(CommandType.F6, false))
            {
                _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE));
            }
        }

        public override void OnFixedUpdate()
        {
            if (_inputController.GetUserInput(InputType.PLAYER_ONE).commands.ContainsPress(CommandType.JUMP, false))
            {
                _dummyAnimation.ManualSetSpriteIndex(_dummyAnimation.GetCurrentAnimation().SPRITE_INDEX + 1);

                if (_dummyAnimation.GetCurrentAnimation().SPRITE_INDEX >= _dummyAnimation.GetCurrentAnimation().SPRITES_COUNT)
                {
                    _dummyAnimation.ManualSetSpriteIndex(0);
                }

                _dummyAnimation.GetCurrentAnimation().UpdateSpriteOnIndex();
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

            _inputController.GetUserInput(InputType.PLAYER_ONE).commands.ClearKeyPressDictionary();
            _inputController.GetUserInput(InputType.PLAYER_ONE).commands.ClearButtonPressDictionary();
        }

        public override void OnLateUpdate()
        {

        }
    }
}