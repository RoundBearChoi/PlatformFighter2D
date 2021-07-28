using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/GameData")]
    public class GameData : ScriptableObject
    {
        public float Runner_FlatGround_RunSpeed = 0f;
        public Vector2 Runner_JumpForce = new Vector2();
        public float JumpPullPercentagePerFixedUpdate = 0f;
        public float SlideSpeedThreshold = 0f;

        [Space(15)]

        public float RunnerCamFollowLimitY = 0f;
        public int DashFixedUpdateCount = 0;
        public float DashForcePerFixedUpdate = 0;

        

        //put elsewhere (general info)
        [Space(15)]
        public Material white_GUIText_material;
        public PhysicsMaterial2D physicsMaterial_NoFrictionNoBounce = null;
        public float CumulativeGravityForcePercentage = 0f;
        public float DefaultFallDeathY = 0f;
        public int InitialFlatGroundCount = 0;
        public float GroundCreationCushionX = 0f;
        public float EnemyCreationCushionX = 0f;
    }
}