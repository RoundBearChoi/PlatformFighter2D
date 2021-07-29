using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Attack_A : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        private bool _dustCreated = false;
        private UserInput _userInput = null;

        public Runner_Attack_A(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 2f, 0.05f));
            _listStateComponents.Add(new OverlapBoxCollision(ownerUnit, GameInitializer.current.GetOverlapBoxCollisionData(OverlapBoxDataType.RUNNER_ATTACK_A)));
            _listStateComponents.Add(new TransitionStateOnEnd(ownerUnit, new Runner_NormalRun(ownerUnit)));

            _userInput = GameInitializer.current.GetStage().USER_INPUT;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (!_dustCreated)
            {
                _dustCreated = true;

                GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.STEP_DUST);
                Units.instance.GetUnit<StepDust>().transform.position = ownerUnit.transform.position + new Vector3(ownerUnit.transform.right.x * 0.8f, 0f, 0f);
            }

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX >= 1)
            {
                if (_userInput.commands.ContainsPress(CommandType.ATTACK_B))
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_Attack_B(ownerUnit));
                }
            }
        }
    }
}