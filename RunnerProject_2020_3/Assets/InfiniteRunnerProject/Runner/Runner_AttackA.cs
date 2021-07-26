using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_AttackA : UnitState
    {
        private bool _dustCreated = false;
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_AttackA(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpRunSpeedOnFlatGround(ownerUnit, 2f, 0.05f));
            _listStateComponents.Add(new OverlapBoxCollision(ownerUnit, GameInitializer.current.GetHitBoxData(HitBoxDataType.RUNNER_ATTACK_A).listSpecs));
            _listStateComponents.Add(new TransitionStateOnEnd(ownerUnit, new Runner_NormalRun(ownerUnit)));
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
                if (GameInitializer.current.GetStage().USER_INPUT.ContainsButtonPress(UserInput.mouse.rightButton))
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_AttackB(ownerUnit));
                }
            }
        }
    }
}