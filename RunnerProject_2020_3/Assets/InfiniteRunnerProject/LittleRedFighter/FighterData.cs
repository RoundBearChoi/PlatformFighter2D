using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "FighterData", menuName = "InfiniteRunner/GameData/FighterData")]
    public class FighterData : ScriptableObject
    {
        public float Gravity = 0f;

        [Space(10)]

        public float DefaultRunSpeed = 0f;
        public float RunSpeedLerpPercentage = 0f;
        public float IdleSlowDownLerpPercentage = 0f;

        [Space(10)]

        public float JumpForce = 0f;
        public float JumpPullPercentagePerFixedUpdate = 0f;
        public float CumulativeGravityForcePercentage = 0f;
        public float HorizontalAirMomentumIncreaseAmount = 0f;
        public float MaxHorizontalAirMomentum = 0f;

        [Space(10)]

        public float AttackASlowDownPercentage = 0f;
    }
}