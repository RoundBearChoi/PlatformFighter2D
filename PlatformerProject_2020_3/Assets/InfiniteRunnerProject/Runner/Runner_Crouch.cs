using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Crouch : UnitState
    {
        public Runner_Crouch()
        {
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, 0.1f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_CROUCH);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (!_ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
            {
                _ownerUnit.listNextStates.Add(new Runner_Crouch_GetUp(_ownerUnit));
            }
        }
    }
}