using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FightStage : BaseStage
    {
        public override void Init()
        {
            _userInput = new UserInput();
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

            InstantiateUnit_ByUnitType(UnitType.LITTLERED_LIGHT);
            Unit littleRed = units.GetUnit<LittleRed>();
            littleRed.SetUserInput(_userInput);

            cameraScript = new CameraScript();
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(new Camera_LerpOnTargetXAndY(0.01f, 0.01f));
            cameraScript.SetFollowTarget(units.GetUnit<LittleRed>().gameObject);
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
            cameraScript.OnUpdate();
            units.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            cameraScript.OnFixedUpdate();
            units.OnFixedUpdate();

            if (_userInput.commands.ContainsPress(CommandType.F5))
            {
                _gameIntializer.stageTransitioner.AddTransition(new FightStageTransition(_gameIntializer));
            }
            
            if (_userInput.commands.ContainsPress(CommandType.F6))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }

            _userInput.commands.ClearKeyDictionary();
            _userInput.commands.ClearButtonDictionary();
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
    }
}