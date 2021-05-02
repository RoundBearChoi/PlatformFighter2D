using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/ObjSpecs/ObjSpecs")]
    public class ObjStatsSO : ScriptableObject
    {
        public float RunnerHorizontalVelocity = 0f;
        public float RunnerVerticalVelocity = 0f;

        private void OnEnable()
        {
            Debugger.Log("scriptable object OnEnable");

            ObjStats.RunnerHorizontalVelocity = RunnerHorizontalVelocity;
            ObjStats.RunnerVerticalVelocity = RunnerVerticalVelocity;
        }
    }
}