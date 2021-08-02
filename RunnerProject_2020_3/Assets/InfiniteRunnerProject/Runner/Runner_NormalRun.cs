using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class Runner_NormalRun : UnitState
    {
        public Runner_NormalRun(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new NormalRunToFall(ownerUnit));
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, BaseInitializer.current.runnerDataSO.Runner_FlatGround_RunSpeed, 0.1f));
            _listStateComponents.Add(new NormalRun_OnUserInput(ownerUnit));
            _listStateComponents.Add(new UpdateCollider2DSize(ownerUnit, new Vector2(0.8f, 3.4f)));

            ownerUnit.gameObject.layer = (int)LayerType.PHYSICAL_UNIT;

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_NORMAL_RUN);
        }

        public override void OnFixedUpdate()
        {
            ownerUnit.unitData.rigidBody2D.mass = 0.2f;

            FixedUpdateComponents();

            if (fixedUpdateCount != 0 && fixedUpdateCount % ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().animationSpec.spriteInterval == 0)
            {
                if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 3 ||
                    ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 7)
                {
                    BaseMessage showStepDust = new ShowStepDustMessage(false, ownerUnit.transform.position - new Vector3(ownerUnit.transform.right.x * 0.8f, 0f, 0f));
                    showStepDust.Register();
                }
            }
        }
    }
}