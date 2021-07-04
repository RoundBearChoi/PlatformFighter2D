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

        public override void Update()
        {
            if (IsOnFlatGround())
            {
                float dif = _unit.unitData.rigidBody2D.velocity.x - StaticRefs.gameData.Runner_NormalRun_StartForce.x;

                if (Mathf.Abs(dif) > 0.001f)
                {
                    //Debugger.Log("lerping speed. current runspeed: " + _unit.unitData.rigidBody2D.velocity.x);

                    float x = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.x, StaticRefs.gameData.Runner_NormalRun_StartForce.x, StaticRefs.gameData.Runner_RunSpeed_LerpRate);

                    _unit.unitData.rigidBody2D.velocity = new Vector2(x, _unit.unitData.rigidBody2D.velocity.y);
                }
                else
                {
                    //Debugger.Log("running at normal speed");
                }
            }
        }

        bool IsOnFlatGround()
        {
            List<Ground> listGrounds = _unit.unitData.collisionStays.GetTouchingGrounds();

            if (listGrounds.Count == 0)
            {
                return false;
            }

            foreach (Ground ground in listGrounds)
            {
                if (Mathf.Abs(ground.transform.rotation.z) >= 0.001f)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

