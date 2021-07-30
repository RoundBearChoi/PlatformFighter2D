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

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, 0.1f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_CROUCH);
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (!ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_DOWN))
            {
                ownerUnit.unitData.listNextStates.Add(new Runner_Crouch_GetUp(ownerUnit));
            }
        }
    }
}