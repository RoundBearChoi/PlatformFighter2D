using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Jump_Up(Unit unit)
        {
            _unit = unit;
        }

        public override void OnEnter()
        {
            _unit.unitData.rigidBody2D.velocity = GameInitializer.current.gameDataSO.Runner_JumpUp_StartForce;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.rigidBody2D.velocity.y < 0f && fixedUpdateCount >= 2)
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Fall(_unit));
            }

            FixedUpdateComponents();
        }

        public override void OnLateUpdate()
        {

        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}