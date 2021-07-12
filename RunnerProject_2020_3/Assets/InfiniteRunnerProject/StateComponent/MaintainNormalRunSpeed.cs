using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class MaintainNormalRunSpeed : StateComponent
    {
        public MaintainNormalRunSpeed(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (GroundCheck.IsOnFlatGround(_unit.unitData.collisionStays))
            {
                if (!_unit.unitData.collisionStays.IsTouchingSide())
                {
                    float dif = _unit.unitData.rigidBody2D.velocity.x - StaticRefs.gameData.Runner_NormalRun_StartForce.x;

                    if (Mathf.Abs(dif) > 0.001f)
                    {
                        float x = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.x, StaticRefs.gameData.Runner_NormalRun_StartForce.x, StaticRefs.gameData.Runner_RunSpeed_LerpRate);
                        _unit.unitData.rigidBody2D.velocity = new Vector2(x, _unit.unitData.rigidBody2D.velocity.y);
                    }
                    else
                    {
                        //Debugger.Log("running at normal speed");
                    }
                }
            }
        }
    }
}