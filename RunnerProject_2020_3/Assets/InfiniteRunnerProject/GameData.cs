using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/GameData")]
    public class GameData : ScriptableObject
    {
        public Vector2 Runner_NormalRun_StartForce = new Vector2();
        public Vector2 Runner_JumpUp_StartForce = new Vector2();

        //public uint Runner_Idle_SpriteInterval = new uint();
        //public Vector2 Runner_Idle_SpriteSize = new Vector2();
        //
        //public uint Runner_Run_SpriteInterval = new uint();
        //public Vector2 Runner_Run_SpriteSize = new Vector2();
        //
        //public uint Runner_Jump_SpriteInterval = new uint();
        //public Vector2 Runner_Jump_SpriteSize = new Vector2();
        //
        //public uint Runner_Death_SpriteInterval = new uint();
        //public Vector2 Runner_Death_SpriteSize = new Vector2();

        public Vector2 RunnerBoxColliderSize = new Vector2();

        public Vector2 ObstacleSpriteSize = new Vector2();
        public Vector2 ObstacleBoxColliderSize = new Vector2();
        public Vector3 ObstacleBoxColliderLocalPos = new Vector3();

        public float InitialUpForce = 0f;
        public AnimationCurve JumpPull;
        public AnimationCurve JumpFall;

        public PhysicsMaterial2D physicsMaterial_NoFrictionNoBounce = null;
    }
}