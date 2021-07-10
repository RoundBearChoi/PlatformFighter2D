using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class Runner_NormalRun : State
    {
        public static bool initialPush = false;
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_NormalRun(Unit unit, UserInput userInput)
        {
            _unit = unit;

            _listStateComponents.Add(new NormalRunToFall(_unit, userInput));
            _listStateComponents.Add(new MaintainNormalRunSpeed(_unit));
            _listStateComponents.Add(new NormalRun_OnUserInput(_unit, userInput));
        }

        public override void OnEnter()
        {
            if (!initialPush)
            {
                _unit.unitData.rigidBody2D.velocity = StaticRefs.gameData.Runner_NormalRun_StartForce;
                initialPush = true;
            }
        }

        public override void OnFixedUpdate()
        {
            UpdateComponents();

            if (updateCount != 0 && updateCount % animationSpec.spriteInterval == 0)
            {
                if (_unit.unitData.spriteAnimations.currentAnimation.SPRITE_INDEX == 3 ||
                    _unit.unitData.spriteAnimations.currentAnimation.SPRITE_INDEX == 7)
                {
                    Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.STEP_DUST, null);
                    Unit dust = Units.instance.GetUnit<StepDust>();
                    dust.transform.position = _unit.transform.position - new Vector3(_unit.transform.right.x * 1f, 0f, 0f);
                    dust.unitData.faceRight = false;

                    //Units.instance.AddCreator(new StepDust_Creator(Stage.currentStage.transform));
                    //Units.instance.ProcessCreators();
                    //Unit dust = Units.instance.GetUnit<StepDust>();
                    //dust.transform.position = _unit.transform.position - new Vector3(_unit.transform.right.x * 1f, 0f, 0f);
                    //dust.unitData.faceRight = false;
                }
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}