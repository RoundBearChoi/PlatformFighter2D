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
        public float Runner_RunSpeed_LerpRate = new float();

        public Vector2 RunnerBoxColliderSize = new Vector2();
        public Vector2 GolemBoxColliderSize = new Vector2();

        public Vector2 ObstacleSpriteSize = new Vector2();
        public Vector2 ObstacleBoxColliderSize = new Vector2();
        public Vector3 ObstacleBoxColliderLocalPos = new Vector3();

        public AnimationCurve JumpPull;
        public AnimationCurve JumpFall;

        public PhysicsMaterial2D physicsMaterial_NoFrictionNoBounce = null;
    }
}