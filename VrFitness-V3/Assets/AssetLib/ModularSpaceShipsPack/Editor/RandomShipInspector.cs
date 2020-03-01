using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(RandomShip))]
public class ObjectBuilderEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        RandomShip myScript = (RandomShip)target;
        
        if (myScript.randomRange)
        {
            myScript.min = EditorGUILayout.IntSlider("Minimum middle segments ", myScript.min, 0, 100);
            myScript.max = EditorGUILayout.IntSlider("Maximum middle segments ", myScript.max, 0, 100);
            if (GUILayout.Button("Create Random"))
            {
                myScript.CreateRandomShip(myScript.min, myScript.max);
            }
        }
        else
        {
            myScript.segments = EditorGUILayout.IntSlider("Middle segments", myScript.segments, 0, 100);
            if (GUILayout.Button("Create Ship"))
            {
                myScript.CreateRandomShip(myScript.segments);
            }
        }
        /*
        myScript.shipPath = EditorGUILayout.TextField("Ship Path", myScript.shipPath);
        myScript.prefabPath = EditorGUILayout.TextField("Prefab Path", myScript.prefabPath);
        myScript.prefabName = EditorGUILayout.TextField("Prefab Name", myScript.prefabName);

        if(GUILayout.Button("Save Prefab"))
        {
            myScript.SaveShip();
        }

        if(myScript.prefabSaved == false)
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.red;
            style.alignment = TextAnchor.MiddleCenter;
            GUILayout.TextArea(myScript.prefabError, style );

        }
        /*
        myScript.autoFillArrays = EditorGUILayout.Toggle("Find ship parts automatically", myScript.autoFillArrays);
        if(!myScript.autoFillArrays)
        {
            //EditorGUIUtility.LookLikeInspector();
            SerializedProperty tps = serializedObject.FindProperty("fronts");
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(tps, true);
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
            //EditorGUIUtility.LookLikeControls();
        }
        */
    }
}