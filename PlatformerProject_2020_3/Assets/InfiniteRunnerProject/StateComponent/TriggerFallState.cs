using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerFallState : StateComponent
    {
        public TriggerFallState(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM) == false &&
                UNIT_DATA.collisionEnters.IsTouchingGround(CollisionType.BOTTOM) == false)
            {
                if (UNIT_DATA.rigidBody2D.velocity.y <= -0.0001f)
                {
                    //multiply/divide runspeed on fall
                    UNIT_DATA.rigidBody2D.velocity = new Vector2(UNIT_DATA.rigidBody2D.velocity.x * BaseInitializer.CURRENT.fighterDataSO.HorizontalMomentumMultiplierOnFall, UNIT_DATA.rigidBody2D.velocity.y);
                    UNIT_DATA.airControl.SetMomentum(UNIT_DATA.rigidBody2D.velocity.x);
                    UNIT_DATA.listNextStates.Add(new LittleRed_Jump_Fall());
                }
            }
        }
    }
}