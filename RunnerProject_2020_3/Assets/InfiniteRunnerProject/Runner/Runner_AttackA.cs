using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_AttackA : State
    {
        private bool _dustCreated = false;
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_AttackA(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new LerpRunSpeedOnFlatGround(_unit, 2f, 0.05f));
            _listStateComponents.Add(new OverlapBoxCollision(_unit, GameInitializer.current.runner_AttackA_OverlapBoxSO.listSpecs));
        }

        public override void OnFixedUpdate()
        {
            if (!_dustCreated)
            {
                _dustCreated = true;

                Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.STEP_DUST, null);
                Units.instance.GetUnit<StepDust>().transform.position = _unit.transform.position + new Vector3(_unit.transform.right.x * 0.8f, 0f, 0f);
            }

            FixedUpdateComponents();

            if (_unit.unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                {
                    _unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit));
                }
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}