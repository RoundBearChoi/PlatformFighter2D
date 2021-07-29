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
            GameInitializer initializer = (GameInitializer)target;

            EditorGUILayout.Space(15);

            if (GUILayout.Button("Find All Default Creation Specs"))
            {
                initializer.FindAllDefaultCreationSpecs();
            }

            if (GUILayout.Button("Find All OverlapBoxCollisionData Specs"))
            {
                initializer.FindAllOverlapBoxCollisionDataSpecs();
            }

            EditorGUILayout.Space(15);

            DrawDefaultInspector();
        }
    }
}