using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Attack : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Golem_Attack(Unit unit)
        {
            _unit = unit;
            _listStateComponents.Add(new OverlapBoxCollision(_unit, GameInitializer.current.golem_Attack_OverlapBoxSO.listSpecs));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_unit.unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                _unit.unitData.listNextStates.Add(new Golem_Idle(_unit));
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}