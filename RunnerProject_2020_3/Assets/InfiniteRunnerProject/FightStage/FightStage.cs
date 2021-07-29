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

            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 8;
            cam.transform.position = new Vector3(8f, 4.5f, -5f);

            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(2)) as GameObject;
            levelObj.transform.parent = this.transform;

            InstantiateUnit_ByUnitType(UnitType.LITTLERED_LIGHT);
            Unit littleRed = units.GetUnit<PlayerUnit>();
            littleRed.SetUserInput(_userInput);
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
            units.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
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
            units.OnLateUpdate();
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return GameInitializer.current.fighterDataSO.CumulativeGravityForcePercentage;
        }
    }
}