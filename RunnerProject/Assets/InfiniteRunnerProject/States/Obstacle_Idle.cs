using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle_Idle : State
    {
        public Obstacle_Idle(UnitData _unitData)
        {
            unitData = _unitData;
        }

        public override void OnEnter()
        {
            unitData.unitTransform.position = new Vector3(15f, 0f, 0f);
        }

        public override void Update()
        {

        }
    }
}