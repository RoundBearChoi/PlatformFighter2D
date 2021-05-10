using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death_Down : State
    {
        public Runner_Death_Down(UnitData unitData)
        {
            _unitData = unitData;
        }

        public override void Update()
        {
            if (_unitData.unitTransform.position.y > -10)
            {
                _unitData.unitTransform.position += new Vector3(0f, -0.2f, 0f);
            }
        }
    }
}