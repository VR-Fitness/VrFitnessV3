using UnityEngine;
using System.Collections;
using System.IO;
#if(UNITY_EDITOR)
using UnityEditor;
using System.Collections.Generic;
#endif

public class RandomShip : MonoBehaviour {

    public bool randomRange = false;

    [HideInInspector]
    public int segments;
    [HideInInspector]
    public int min;

    [HideInInspector]
    public int max = 5;

    [HideInInspector]
    public string shipPath = "Assets/ModularSpaceShipsPack/";

    [HideInInspector]
    public const string frontPath = "FrontModules";

    [HideInInspector]
    public const string middlePath = "MiddleModules";

    [HideInInspector]
    public const string backPath = "BackModules";

    [HideInInspector]
    public string prefabPath = "/ModularSpaceShipsPack/ShipPrefabs/";


    [HideInInspector]
    public string prefabName = "myPrefab";


    GameObject ship = null;
    
    //[HideInInspector]
    public Transform[] fronts;

    //[HideInInspector]
    public Transform[] middles;

    //[HideInInspector]
    public Transform[] backs;

    const int MODULE_LENGTH = 2;

#if(UNITY_EDITOR)
    void GetParts()
    {
        string[] filters = new string[1];
        string[] results;
        HashSet<Transform> assetResults = new HashSet<Transform>();
        if (fronts == null || fronts.Length == 0)
        {
            
            filters[0] = shipPath + frontPath;
            results = AssetDatabase.FindAssets("", filters);  //AssetDatabase.LoadAllAssetsAtPath(shipPath + frontPath) as Transform[];
            
            for(int i = 0; i < results.Length; i++)
            {
                Transform t = (AssetDatabase.LoadAssetAtPath<Transform>(AssetDatabase.GUIDToAssetPath(results[i])));
                if (t == null)
                    Debug.Log("Null at " + i);
                assetResults.Add(t);
            }
            fronts = new Transform[assetResults.Count];
            assetResults.CopyTo(fronts);
        }
        if (middles == null || middles.Length == 0)
        {
            assetResults.Clear();
            filters[0] = shipPath + middlePath;
            results = AssetDatabase.FindAssets("", filters);  //AssetDatabase.LoadAllAssetsAtPath(shipPath + frontPath) as Transform[];

            for (int i = 0; i < results.Length; i++)
            {
                assetResults.Add(AssetDatabase.LoadAssetAtPath<Transform>(AssetDatabase.GUIDToAssetPath(results[i])));
            }
            middles = new Transform[assetResults.Count];
            assetResults.CopyTo(middles);
        }
        if (backs == null || backs.Length == 0)
        {
            assetResults.Clear();
            filters[0] = shipPath + backPath;
            results = AssetDatabase.FindAssets("", filters);  //AssetDatabase.LoadAllAssetsAtPath(shipPath + frontPath) as Transform[];
           
            for (int i = 0; i < results.Length; i++)
            {
                assetResults.Add(AssetDatabase.LoadAssetAtPath<Transform>(AssetDatabase.GUIDToAssetPath(results[i])));
            }
            backs = new Transform[assetResults.Count];
            assetResults.CopyTo(backs);
        }
    }
#endif

    public void CreateRandomShip(int sections)
    {
        GetParts();
        ship = gameObject;//new GameObject(prefabName);
        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        Transform tempObject;
        tempObject = GameObject.Instantiate(fronts[Random.Range(0, fronts.Length)], new Vector3(0, 0, 0.5f * sections * MODULE_LENGTH + MODULE_LENGTH * 0.5f), Quaternion.identity) as Transform;
        tempObject.SetParent(ship.transform, false);
        for (int i = 0; i < sections; i++)
        {
            tempObject = GameObject.Instantiate(middles[Random.Range(0, middles.Length)], new Vector3(0, 0, 0.5f * (-sections * MODULE_LENGTH) + MODULE_LENGTH * i + MODULE_LENGTH * 0.5f), Quaternion.identity) as Transform;
            tempObject.SetParent(ship.transform, false);
        }
        tempObject = GameObject.Instantiate(backs[Random.Range(0, backs.Length)], new Vector3(0, 0, 0.5f * -sections * MODULE_LENGTH - MODULE_LENGTH * 0.5f), Quaternion.identity) as Transform;
        tempObject.SetParent(ship.transform, false);
    }

    public void CreateRandomShip(int min, int max)
    {
        int length = Random.Range(min, max);
        Debug.Log("POOTIS: " + length  + " MIN: " + min + " MAX: " + max);
        CreateRandomShip(length);
    }

    [HideInInspector]
    public bool prefabSaved = true;
    [HideInInspector]
    public string prefabError;

    /*
    public void SaveShip()
    {
#if (UNITY_EDITOR)
        if (ship != null)
        {
            if (File.Exists(Application.dataPath + prefabPath + prefabName + ".prefab"))
            {
                prefabError = ("Prefab with this name already exists.");
                Debug.LogWarning(prefabError);
                prefabSaved = false;
            }
            else
            {
                Directory.CreateDirectory(Application.dataPath + prefabPath);
                PrefabUtility.CreatePrefab( "Assets" + prefabPath + prefabName + ".prefab", ship);
                prefabSaved = true;
                Debug.Log("Prefab saved successfully as " + prefabName);
            }
        }
        else
        {
            prefabError = ("No ship was created before hitting save.");
            Debug.Log(prefabError);
            prefabSaved = false;
        }
#endif
    }
    */
}
