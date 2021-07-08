using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/GolemSpriteData")]
    public class GolemSpriteData : ScriptableObject
    {
        public Vector2 GolemBoxColliderSize = new Vector2();
        public string Golem_SpriteName;
        public uint Golem_SpriteInterval = new uint();
        public Vector2 Golem_SpriteSize = new Vector2();
    }
}