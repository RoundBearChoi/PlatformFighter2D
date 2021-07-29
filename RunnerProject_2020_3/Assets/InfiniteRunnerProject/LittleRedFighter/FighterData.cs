using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "FighterData", menuName = "InfiniteRunner/GameData/FighterData")]
    public class FighterData : ScriptableObject
    {
        public float DefaultRunSpeed = 0f;
        public float RunSpeedLerpPercentage = 0f;
        public float IdleSlowDownLerpPercentage = 0f;
    }
}