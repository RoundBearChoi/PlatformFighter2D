using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Smash_Air_Land : UnitState
    {
        public Runner_Smash_Air_Land(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, 0.3f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_SMASH_AIR_LAND);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            //cancel last frame and go straight to crouch
            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX >= 5)
            {
                if (ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_DOWN))
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_Crouch(ownerUnit));
                }
            }

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                if (ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_DOWN))
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_Crouch(ownerUnit));
                }
                else
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_NormalRun(ownerUnit));
                }
            }
        }
    }
}