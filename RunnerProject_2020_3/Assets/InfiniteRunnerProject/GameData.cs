using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/GameData")]
    public class GameData : ScriptableObject
    {
        public Vector2 Runner_JumpUp_StartForce = new Vector2();
        public float JumpPullPercentagePerFixedUpdate = 0f;

        [Space(15)]

        public PhysicsMaterial2D physicsMaterial_NoFrictionNoBounce = null;

        [Space(15)]

        public float RunnerCamFollowLimitY = 0f;
        public float DefaultFallDeathY = 0f;
        public int InitialFlatGroundCount = 0;
        
        public int DashFixedUpdateCount = 0;
        public float DashForcePerFixedUpdate = 0;
    }
}