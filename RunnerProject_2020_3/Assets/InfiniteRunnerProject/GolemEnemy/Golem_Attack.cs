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
            _listStateComponents.Add(new OverlapBoxCollision(ownerUnit, GameInitializer.current.hitBoxData.golem_Attack_A.listSpecs));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                ownerUnit.unitData.listNextStates.Add(new Golem_Idle(ownerUnit));
            }
        }
    }
}