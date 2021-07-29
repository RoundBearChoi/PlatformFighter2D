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
        public Vector2 JumpForce_FromIdle = Vector2.zero;
        public float JumpPullPercentagePerFixedUpdate = 0f;
        public float CumulativeGravityForcePercentage = 0f;
    }
}