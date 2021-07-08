using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/RunnerMovementSpriteData")]
    public class RunnerMovementSpriteData : ScriptableObject
    {
        public string Idle_SpriteName;
        public uint Idle_SpriteInterval = new uint();
        public Vector2 Idle_SpriteSize = new Vector2();
        public List<AdditionalInterval> Idle_AdditionalIntervals = new List<AdditionalInterval>();

        [Space(10)]

        public string Run_SpriteName;
        public uint Run_SpriteInterval = new uint();
        public Vector2 Run_SpriteSize = new Vector2();

        [Space(10)]

        public string Jump_SpriteName;
        public uint Jump_SpriteInterval = new uint();
        public Vector2 Jump_SpriteSize = new Vector2();

        [Space(10)]

        public string Death_SpriteName;
        public uint Death_SpriteInterval = new uint();
        public Vector2 Death_SpriteSize = new Vector2();
    }
}