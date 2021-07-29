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

            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(2)) as GameObject;
            levelObj.transform.parent = this.transform;
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
            units.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f5Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new FightStageTransition(_gameIntializer));
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f6Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
        }
    }
}