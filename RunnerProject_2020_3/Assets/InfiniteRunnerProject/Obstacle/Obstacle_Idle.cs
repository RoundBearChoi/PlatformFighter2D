using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle_Idle : State
    {
        public Obstacle_Idle(UnitData data)
        {
            _unitData = data;
        }

        public override void OnEnter()
        {
            _unitData.unitTransform.position = new Vector3(10f, 0f, 0f);
        }

        public override void Update()
        {

        }
    }
}