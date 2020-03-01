using UnityEngine;
using System.Collections;
#if(UNITY_EDITOR)
using UnityEditor;
using System.Collections.Generic;
#endif
namespace ModularSpaceshipPack
{
    public class MaterialSelector : MonoBehaviour
    {
        public string materialPath = "Assets/AssetLib/ModularSpaceShipsPack/Materials/Skins";

        [HideInInspector]
        public Material[] skinList;

        [HideInInspector]
        public string[] skinNames;

        [HideInInspector]
        public bool materialError = false;

        public void GetStringNames()
        {

            Debug.Log("Get string names");
            HashSet<Material> assetResults = new HashSet<Material>();
            string[] searchPath = new string[1];
            searchPath[0] = materialPath;
            string[] results = AssetDatabase.FindAssets("", searchPath);  //AssetDatabase.LoadAllAssetsAtPath(shipPath + frontPath) as Transform[];
            if (results == null || results.Length == 0)
            {
                materialError = true;
                skinNames = new string[0];
            }
            else
            {
                materialError = false;
                for (int i = 0; i < results.Length; i++)
                {
                    assetResults.Add(AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath(results[i])));
                }
                skinList = new Material[assetResults.Count];
                assetResults.CopyTo(skinList);
                skinNames = new string[skinList.Length];
                for (int i = 0; i < skinList.Length; i++)
                {
                    skinNames[i] = skinList[i].name;
                }
            }
        }
        

        [ContextMenu("Apply Skin")]
        public void ApplySkin(int index)
        {
            MeshRenderer[] meshes = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].material = skinList[index];
            }
        }
    }
}