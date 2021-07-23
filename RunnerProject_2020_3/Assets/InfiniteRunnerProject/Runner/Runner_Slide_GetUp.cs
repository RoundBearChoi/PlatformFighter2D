using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Slide_GetUp : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        //private bool _stepDustCreated = false;

        public Runner_Slide_GetUp(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new UpdateCollider2DSize(ownerUnit, new Vector2(0.8f, 3.4f)));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            //if (!_stepDustCreated)
            //{
            //    _stepDustCreated = true;
            //
            //    Vector3 offset = new Vector3(1.15f, 0f, 0f);
            //    bool faceRight = true;
            //
            //    if (!ownerUnit.unitData.facingRight)
            //    {
            //        offset *= -1f;
            //        faceRight = false;
            //    }
            //
            //    BaseMessage showStepDust = new ShowStepDustMessage(faceRight, ownerUnit.transform.position + offset);
            //    showStepDust.Register();
            //}

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                ownerUnit.unitData.listNextStates.Add(new Runner_NormalRun(ownerUnit));
            }
        }
    }
}