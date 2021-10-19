using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class Runner_NormalRun : UnitState
    {
        public Runner_NormalRun()
        {
            _listStateComponents.Add(new NormalRunToFall(this));
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, BaseInitializer.CURRENT.runnerDataSO.Runner_FlatGround_RunSpeed, 0.1f));
            _listStateComponents.Add(new NormalRun_OnUserInput(this));
            _listStateComponents.Add(new UpdateCollider2DSize(this, new Vector2(0.8f, 3.4f)));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_NORMAL_RUN);
        }

        public override void OnFixedUpdate()
        {
            ownerUnit.gameObject.layer = (int)LayerType.PHYSICAL_UNIT;
            ownerUnit.unitData.rigidBody2D.mass = 0.2f;

            FixedUpdateComponents();

            if (fixedUpdateCount != 0 && fixedUpdateCount % ownerUnit.spriteAnimations.GetCurrentAnimation().SPRITE_INTERVAL == 0)
            {
                if (ownerUnit.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 3 ||
                    ownerUnit.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 7)
                {
                    BaseMessage showStepDust = new Message_ShowStepDust(false, ownerUnit.transform.position - new Vector3(ownerUnit.transform.right.x * 0.8f, 0f, 0f), new Vector2(1f, 1f), 4);
                    showStepDust.Register();
                }
            }
        }
    }
}