using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death_Up : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_SampleDeathAnimation");

        public Runner_Death_Up(UnitData unitData)
        {
            Debugger.Log("runner is dead");
            _unitData = unitData;
        }

        public override void Update()
        {
            if (updateCount < 20)
            {
                _unitData.unitTransform.position += new Vector3(0f, 0.15f, 0f);
            }
            else
            {
                nextState = new Runner_Death_Down(_unitData);
            }
        }

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }
    }
}