using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitCreationSpec : ScriptableObject
    {
        public UnitType unitType;
        public Vector3 localPosition;
        public Quaternion localRotation;

    }
}