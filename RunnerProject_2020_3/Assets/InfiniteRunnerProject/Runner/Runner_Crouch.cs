using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Crouch : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        private UserInput _userInput = null;

        public Runner_Crouch(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, 0.1f));

            _userInput = GameInitializer.current.GetStage().USER_INPUT;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (!_userInput.userCommands.ContainsHold(CommandType.MOVE_DOWN))
            {
                ownerUnit.unitData.listNextStates.Add(new Runner_Crouch_GetUp(ownerUnit));
            }
        }
    }
}