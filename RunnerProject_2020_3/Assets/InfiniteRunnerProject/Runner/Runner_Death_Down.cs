using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death_Down : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_SampleDeathAnimation");

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

        public override Hash128 GetHash()
        {
            return animationHash;
        }
    }
}