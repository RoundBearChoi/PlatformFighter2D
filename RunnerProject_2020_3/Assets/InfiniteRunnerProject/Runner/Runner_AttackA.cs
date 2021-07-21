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
            _listStateComponents.Add(new OverlapBoxCollision(ownerUnit, GameInitializer.current.runner_AttackA_OverlapBoxSO.listSpecs));
        }

        public override void OnFixedUpdate()
        {
            if (!_dustCreated)
            {
                _dustCreated = true;

                Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.STEP_DUST);
                Units.instance.GetUnit<StepDust>().transform.position = ownerUnit.transform.position + new Vector3(ownerUnit.transform.right.x * 0.8f, 0f, 0f);
            }

            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_NormalRun(ownerUnit));
                }
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}