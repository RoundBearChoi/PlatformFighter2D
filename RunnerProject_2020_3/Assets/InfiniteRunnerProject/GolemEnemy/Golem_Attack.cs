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
            ownerUnit = unit;
            _listStateComponents.Add(new OverlapBoxCollision(ownerUnit, GameInitializer.current.golem_Attack_OverlapBoxSO.listSpecs));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                ownerUnit.unitData.listNextStates.Add(new Golem_Idle(ownerUnit));
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}