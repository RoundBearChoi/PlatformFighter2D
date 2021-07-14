using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseUnitCreationSpec : ScriptableObject
    {
        [Space(15)]

        public UnitType unitType;
        public Vector3 localPosition;
        public Quaternion localRotation;
        public Vector2 BoxCollider2DSize;
        public bool faceRight = true;
        public int hp = 0;

        [Space(15)]

        public SetInitialState_Event setInitialState;

        [Space(15)]

        public SetUpdater_Event setUpdater;

        [Space(15)]

        public List<SpriteAnimationSpec> listSpriteAnimationSpecs = new List<SpriteAnimationSpec>();
    }
}