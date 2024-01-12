using UnityEditor;
using UnityEngine;


namespace Studio23.SS2.AuthSystem.Editor
{
    public class AuthSystemInstaller : UnityEditor.Editor
    {
        [MenuItem("Studio-23/AuthSystem/Install", false, 10)]
        static void InstantiatePrefab()
        {
            GameObject prefab = Resources.Load<GameObject>("AuthSystem/DemoPrefab");

            if (prefab != null)
            {
                
                GameObject instantiatedObject = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

                if (instantiatedObject != null)
                {
                   
                    instantiatedObject.name = "AuthSystem";
                }
                else
                {
                    Debug.LogError("Failed to instantiate the prefab.");
                }
            }
            else
            {
                Debug.LogError("Prefab not found. Make sure to provide the correct path to your prefab.");
            }
        }
    }
}