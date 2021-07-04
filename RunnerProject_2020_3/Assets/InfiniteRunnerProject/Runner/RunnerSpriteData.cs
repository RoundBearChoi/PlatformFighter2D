using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/RunnerSpriteData")]
    public class RunnerSpriteData : ScriptableObject
    {
        public int Idle_SpriteInterval = new int();
        public Vector2 Idle_SpriteSize = new Vector2();
        public List<AdditionalInterval> Idle_AdditionalIntervals = new List<AdditionalInterval>();

        [Space(10)]

        public int Run_SpriteInterval = new int();
        public Vector2 Run_SpriteSize = new Vector2();

        [Space(10)]

        public int StraightPunch_SpriteInterval = new int();
        public Vector2 StraightPunch_SpriteSize = new Vector2();
        public Vector2 StraightPunch_AdditionalOffset = new Vector2();

        [Space(10)]

        public int Jump_SpriteInterval = new int();
        public Vector2 Jump_SpriteSize = new Vector2();

        [Space(10)]

        public int Death_SpriteInterval = new int();
        public Vector2 Death_SpriteSize = new Vector2();
    }
}