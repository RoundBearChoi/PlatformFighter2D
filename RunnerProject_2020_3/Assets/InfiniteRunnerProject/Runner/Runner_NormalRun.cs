using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class Runner_NormalRun : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_NormalRun(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new NormalRunToFall(_unit));
            _listStateComponents.Add(new LerpRunSpeedOnFlatGround(_unit, 3.5f, 0.1f));
            _listStateComponents.Add(new NormalRun_OnUserInput(_unit));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (fixedUpdateCount != 0 && fixedUpdateCount % animationSpec.spriteInterval == 0)
            {
                if (_unit.unitData.spriteAnimations.currentAnimation.SPRITE_INDEX == 3 ||
                    _unit.unitData.spriteAnimations.currentAnimation.SPRITE_INDEX == 7)
                {
                    Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.STEP_DUST);
                    Unit dust = Units.instance.GetUnit<StepDust>();
                    dust.transform.position = _unit.transform.position - new Vector3(_unit.transform.right.x * 1f, 0f, 0f);
                    dust.unitData.facingRight = false;
                }
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}