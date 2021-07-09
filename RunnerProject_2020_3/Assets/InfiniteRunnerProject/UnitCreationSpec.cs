using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/UnitCreationSpecs/DefaultUnitCreationSpec")]
    public class UnitCreationSpec : ScriptableObject
    {
        public UnitType unitType;
        public Vector3 localPosition;
        public Quaternion localRotation;

        [Space(20)]

        public List<SpriteAnimationSpec> listSpriteAnimationSpecs = new List<SpriteAnimationSpec>();

        [Space(20)]

        public UpdaterSettings updaterSettings;
    }
}