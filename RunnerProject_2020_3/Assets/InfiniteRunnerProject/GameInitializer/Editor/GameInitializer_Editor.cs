using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RB
{
    [CustomEditor(typeof(GameInitializer))]
    public class AbilityListToArrayEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameInitializer initializer = (GameInitializer)target;

            if (GUILayout.Button("Find All Default Creation Specs"))
            {
                initializer.FindAllDefaultCreationSpecs();
            }
        }
    }
}