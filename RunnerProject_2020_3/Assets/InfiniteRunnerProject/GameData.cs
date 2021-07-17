using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/GameData")]
    public class GameData : ScriptableObject
    {
        public Vector2 Runner_JumpUp_StartForce = new Vector2();

        public AnimationCurve JumpPull;
        public AnimationCurve JumpFall;

        public PhysicsMaterial2D physicsMaterial_NoFrictionNoBounce = null;
    }
}