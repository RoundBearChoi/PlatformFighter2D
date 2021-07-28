using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Attack_B : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Attack_B(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new OverlapBoxCollision(ownerUnit, GameInitializer.current.hitBoxData.runner_Attack_B.listSpecs));
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, 0.1f));
            _listStateComponents.Add(new TransitionStateOnEnd(ownerUnit, new Runner_NormalRun(ownerUnit)));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX >= 2)
            {
                if (ButtonIsPressed(UserInput.mouse.leftButton))
                {
                    if (ownerUnit.unitData.comboHitCount.GetCount() >= 2)
                    {
                        ownerUnit.unitData.listNextStates.Add(new Runner_Smash_Grounded(ownerUnit));
                    }
                    else
                    {
                        ownerUnit.unitData.listNextStates.Add(new Runner_Attack_A_Dash(ownerUnit));
                    }
                }

                if (ButtonIsPressed(UserInput.mouse.rightButton))
                {
                    if (ownerUnit.unitData.comboHitCount.GetCount() >= 2)
                    {
                        ownerUnit.unitData.listNextStates.Add(new Runner_Overhead(ownerUnit));
                    }
                }
            }
        }
    }
}