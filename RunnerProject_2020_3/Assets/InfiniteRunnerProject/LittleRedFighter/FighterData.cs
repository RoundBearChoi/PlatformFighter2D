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
        public float HorizontalAirMomentumIncreaseAmount = 0f;
        public float MaxHorizontalAirMomentum = 0f;

        [Space(10)]
        public float DashForce = 0f;
        public float DashFixedUpdates = 0f;

        [Space(10)]

        public float WallJumpForce = 0f;
        public float WallJumpHorizontalMomentum = 0f;
        public float WallFallHorizontalMomentum = 0f;
        public float MaxWallSlideFallSpeed = 0f;

        [Space(10)]

        public float CumulativeGravityForcePercentage = 0f;

        [Space(10)]

        public float AttackASlowDownPercentage = 0f;

        [Space(10)]

        public float Camera_z = 0f;
        public float OldCity_BottomFog_z = 0f;
        public float OldCity_TopFog_z = 0f;
        public float BloodEffects_z = 0f;
        public float DustEffects_z = 0f;
        public float Players_z = 0f;
        public float tempPlatforms_z = 0f;
        public float OldCity_Platforms_z = 0f;
        public float OldCity_Arches_z = 0f;
        public float OldCity_Pillars_z = 0f;

    }
}