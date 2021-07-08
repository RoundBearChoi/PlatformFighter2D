using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/RunnerAttackSpriteData")]
    public class RunnerAttackSpriteData : ScriptableObject
    {
        public State initialState;
        public string AttackA_SpriteName;
        public uint AttackA_SpriteInterval = new uint();
        public Vector2 AttackA_SpriteSize = new Vector2();
        public Vector2 AttackA_AdditionalOffset = new Vector2();
    }
}