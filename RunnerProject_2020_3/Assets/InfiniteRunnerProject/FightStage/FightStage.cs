using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FightStage : BaseStage
    {
        [SerializeField]
        private InputType _currentInputSelection = InputType.PLAYER_ONE;
        private InputType _prevInputSelection = InputType.NONE;

        public override void Init()
        {
            units = new Units(this);

            Physics2D.gravity = new Vector2(0f, GameInitializer.current.fighterDataSO.Gravity);

            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 8;
            cam.transform.position = new Vector3(8f, 4.5f, -5f);

            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(2)) as GameObject;
            levelObj.transform.parent = this.transform;

            GameInitializer.current.GetStage().InstantiateUnits_ByUnitType(UnitType.OLD_CITY);

            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_LIGHT);
            Unit player1 = units.GetUnit<LittleRed>();

            UserInput input = _inputController.AddInput();
            _currentInputSelection = input.INPUT_TYPE;
            _prevInputSelection = input.INPUT_TYPE;
            player1.SetUserInput(input);

            cameraScript = new CameraScript();
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(GetDefaultCameraState());
            cameraScript.SetFollowTarget(units.GetUnit<LittleRed>().gameObject);

            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK);
            Unit player2 = units.GetUnit<LittleRed>();
            player2.SetUserInput(_inputController.AddInput());
        }

        public override void OnUpdate()
        {
            _inputController.GetUserInput(_currentInputSelection).OnUpdate();
            cameraScript.OnUpdate();
            units.OnUpdate();

            if (_inputController.GetUserInput(_currentInputSelection).commands.ContainsPress(CommandType.F5))
            {
                _gameIntializer.stageTransitioner.AddTransition(new FightStageTransition(_gameIntializer));
            }

            if (_inputController.GetUserInput(_currentInputSelection).commands.ContainsPress(CommandType.F6))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }

            if (_inputController.GetUserInput(_currentInputSelection).commands.ContainsPress(CommandType.F7))
            {
                _currentInputSelection++;

                if ((int)_currentInputSelection > _inputController.GetCount())
                {
                    _currentInputSelection = InputType.PLAYER_ONE;
                }
            }
        }

        public override void OnFixedUpdate()
        {
            cameraScript.OnFixedUpdate();
            units.OnFixedUpdate();

            _inputController.GetUserInput(_currentInputSelection).commands.ClearKeyDictionary();
            _inputController.GetUserInput(_currentInputSelection).commands.ClearButtonDictionary();

            if (_currentInputSelection != _prevInputSelection)
            {
                _inputController.ClearAllKeysAndButtons();
                _prevInputSelection = _currentInputSelection;
            }
        }

        public override void OnLateUpdate()
        {
            cameraScript.OnLateUpdate();
            units.OnLateUpdate();
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return GameInitializer.current.fighterDataSO.CumulativeGravityForcePercentage;
        }

        public override CameraState GetDefaultCameraState()
        {
            return new Camera_LerpOnTargetXAndY(0.01f, 0.01f);
        }
    }
}