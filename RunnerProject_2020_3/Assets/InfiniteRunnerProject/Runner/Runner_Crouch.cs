using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Crouch : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Crouch(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpRunSpeedOnFlatGround(ownerUnit, 0f, 0.1f));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (!GameInitializer.current.GetStage().USER_INPUT.ContainsKeyHold(UserInput.keyboard.sKey))
            {
                ownerUnit.unitData.listNextStates.Add(new Runner_Crouch_GetUp(ownerUnit));
            }
        }
    }
}