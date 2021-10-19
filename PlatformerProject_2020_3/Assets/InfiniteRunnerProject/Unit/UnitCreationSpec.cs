using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "DefaultUnitCreationSpec", menuName = "InfiniteRunner/UnitCreationSpecs/DefaultUnitCreationSpec")]
    public class UnitCreationSpec : ScriptableObject
    {
        [Space(15)]

        public UnitType unitType;
        public Vector3 localPosition;
        public Quaternion localRotation;
        public Vector2 BoxCollider2DSize;
        public bool faceRight = true;
        public uint hp = 0;

        [Space(15)]

        public SetInitialState_Event setInitialState;

        [Space(15)]

        public int SpriteNameIndex = 0;

        [Space(5)]
        public List<SpriteAnimationSpec> listSpriteAnimationSpecs = new List<SpriteAnimationSpec>();
    }
}