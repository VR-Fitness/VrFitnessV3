using UnityEngine;
using System.Collections;
using UnityEditor;


namespace ModularSpaceshipPack
{
    [CustomEditor(typeof(MaterialSelector))]
    public class MaterialSelectorInspector : Editor
    {
        public int index = -1;

        MaterialSelector myScript;
        int oldIndex = -1;
        void OnEnable()
        {
            myScript = (MaterialSelector)target;
            myScript.GetStringNames();
        }

        string oldString = "";
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            if(!myScript.materialError)
                index = EditorGUILayout.Popup(index, myScript.skinNames);
            if(oldString != myScript.materialPath)
            {
                oldString = myScript.materialPath;
                myScript.GetStringNames();
            }

            if (index != oldIndex)
            {
                oldIndex = index;
                myScript.ApplySkin(index);
            }

            if(myScript.materialError)
            {
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.red;
                style.alignment = TextAnchor.MiddleCenter;
                GUILayout.TextArea("No materials were found at the path \n" + myScript.materialPath, style);
            }
        }
    }
}