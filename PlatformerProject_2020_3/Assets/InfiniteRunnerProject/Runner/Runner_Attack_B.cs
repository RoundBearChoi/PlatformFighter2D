using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Attack_B : UnitState
    {
        public Runner_Attack_B()
        {
            _listStateComponents.Add(new OverlapBoxCollision(this, BaseInitializer.CURRENT.GetOverlapBoxCollisionData(OverlapBoxDataType.RUNNER_ATTACK_B)));
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, 0.1f));
            _listStateComponents.Add(new TransitionStateOnEnd(this, new Runner_NormalRun()));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_ATTACK_B);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX >= 2)
            {
                if (_ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
                {
                    //if (ownerUnit.unitData.comboHitCount.GetCount() >= 2)
                    //{
                    //    ownerUnit.unitData.rigidBody2D.velocity = new Vector2(ownerUnit.unitData.rigidBody2D.velocity.x, BaseInitializer.current.runnerDataSO.Runner_ComboSmashJumpForce);
                    //    ownerUnit.listNextStates.Add(new Runner_ComboTransitionTo_Smash(ownerUnit));
                    //}
                    //else
                    //{
                    //    ownerUnit.listNextStates.Add(new Runner_Attack_A_Dash(ownerUnit));
                    //}
                }

                if (_ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_B, false))
                {
                    //if (ownerUnit.unitData.comboHitCount.GetCount() >= 2)
                    //{
                    //    ownerUnit.listNextStates.Add(new Runner_Overhead(ownerUnit));
                    //}
                }
            }
        }
    }
}