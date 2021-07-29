using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Idle : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public LittleRed_Idle(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, 0.2f));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT) || ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_RIGHT))
            {
                if (ownerUnit.unitData.rigidBody2D.velocity.x > 0f)
                {
                    ownerUnit.unitData.facingRight = true;
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Run(ownerUnit));
                }
                else
                {
                    float x = Mathf.Lerp(ownerUnit.unitData.rigidBody2D.velocity.x, 0.1f, 0.1f);
                    ownerUnit.unitData.rigidBody2D.velocity = new Vector2(x, ownerUnit.unitData.rigidBody2D.velocity.y);
                }
            }
        }
    }
}