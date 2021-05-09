using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/GameData")]
    public class GameData : ScriptableObject
    {
        public float RunnerHorizontalVelocity = 0f;
        public float InitialUpForce = 0f;
        public AnimationCurve JumpPull;
        public AnimationCurve JumpFall;
    }
}