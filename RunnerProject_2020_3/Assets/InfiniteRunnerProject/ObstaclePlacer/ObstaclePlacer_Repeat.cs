using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ObstaclePlacer_Repeat : State
    {
        private Unit _runner = null;

        public ObstaclePlacer_Repeat(UnitData data, Unit runner)
        {
            _unitData = data;
            _runner = runner;
        }

        public override void Update()
        {

        }
    }
}