using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Smash_Air_Land : UnitState
    {
        public Runner_Smash_Air_Land(Unit unit)
        {
            _ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, 0.3f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_SMASH_AIR_LAND);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            //cancel last frame and go straight to crouch
            if (_ownerUnit.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX >= 5)
            {
                if (_ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
                {
                    _ownerUnit.listNextStates.Add(new Runner_Crouch());
                }
            }

            if (_ownerUnit.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                if (_ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
                {
                    _ownerUnit.listNextStates.Add(new Runner_Crouch());
                }
                else
                {
                    _ownerUnit.listNextStates.Add(new Runner_NormalRun());
                }
            }
        }
    }
}