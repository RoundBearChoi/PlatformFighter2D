using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerFallState : StateComponent
    {
        public TriggerFallState(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) == false &&
                _unit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM) == false)
            {
                if (_unit.unitData.rigidBody2D.velocity.y <= -0.0001f)
                {
                    //multiply/divide runspeed on fall
                    _unit.unitData.rigidBody2D.velocity = new Vector2(_unit.unitData.rigidBody2D.velocity.x * BaseInitializer.CURRENT.fighterDataSO.HorizontalMomentumMultiplierOnFall, _unit.unitData.rigidBody2D.velocity.y);
                    _unit.unitData.airControl.SetMomentum(_unit.unitData.rigidBody2D.velocity.x);
                    _unit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(_unit));
                }
            }
        }
    }
}