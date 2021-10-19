using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Attack_A : UnitState
    {
        private bool _dustCreated = false;

        public Runner_Attack_A(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 2f, 0.05f));
            _listStateComponents.Add(new OverlapBoxCollision(this, BaseInitializer.CURRENT.GetOverlapBoxCollisionData(OverlapBoxDataType.RUNNER_ATTACK_A)));
            _listStateComponents.Add(new TransitionStateOnEnd(this, new Runner_NormalRun()));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_ATTACK_A);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (!_dustCreated)
            {
                _dustCreated = true;

                BaseInitializer.CURRENT.STAGE.InstantiateUnit_ByUnitType(UnitType.STEP_DUST, new StepDust_DefaultState());
                Units.instance.GetUnit<StepDust>().transform.position = ownerUnit.transform.position + new Vector3(ownerUnit.transform.right.x * 0.8f, 0f, 0f);
            }

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX >= 1)
            {
                if (ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_B, false))
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_Attack_B());
                }
            }
        }
    }
}