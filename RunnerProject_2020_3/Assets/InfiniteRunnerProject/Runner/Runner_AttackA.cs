using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_AttackA : State
    {
        private UserInput _userInput = null;
        private bool _dustCreated = false;
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_AttackA(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;

            List<OverlapBoxSpecs> listOverlapBoxSpecs = new List<OverlapBoxSpecs>();
            ContactFilter2D contactFilter = new ContactFilter2D();
            OverlapBoxBounds boxBounds = new OverlapBoxBounds(new Vector2(1f, 1f), new Vector2(10f, 10f), 0f);
            listOverlapBoxSpecs.Add(new OverlapBoxSpecs(1, 1, 10, boxBounds, contactFilter));

            _listStateComponents.Add(new LerpRunSpeed(_unit, 2f, 0.05f));
            _listStateComponents.Add(new OverlapBoxCollision(_unit, listOverlapBoxSpecs));
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
                    _unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit, _userInput));
                }
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}