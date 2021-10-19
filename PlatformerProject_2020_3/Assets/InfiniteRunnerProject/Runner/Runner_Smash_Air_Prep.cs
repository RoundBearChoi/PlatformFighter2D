using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Smash_Air_Prep : UnitState
    {
        public Runner_Smash_Air_Prep()
        {
            _listStateComponents.Add(new LerpVerticalSpeed_Air(this, -0.1f, 0.05f));
            _listStateComponents.Add(new LerpHorizontalSpeed_Air(this, 0.01f, 0.05f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_SMASH_AIR_PREP);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                if (_ownerUnit.unitData.rigidBody2D.velocity.y < 0f)
                {
                    _ownerUnit.listNextStates.Add(new Runner_Smash_Air_Fall(_ownerUnit));
                }
            }
        }
    }
}