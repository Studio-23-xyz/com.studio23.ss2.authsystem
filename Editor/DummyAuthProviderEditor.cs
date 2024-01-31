using Studio23.SS2.AuthSystem.Data;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DummyAuthProviderEditor : MonoBehaviour
{
    [MenuItem("Studio-23/AuthSystem/Providers/DummyAuthProvider", false, 10)]
    static void CreateDefaultProvider()
    {
        DummyAuthProvider providerSettings = ScriptableObject.CreateInstance<DummyAuthProvider>();

        // Create the resource folder path
        string resourceFolderPath = "Assets/Resources/AuthSystem/Providers";

        if (!Directory.Exists(resourceFolderPath))
        {
            Directory.CreateDirectory(resourceFolderPath);
        }

        // Create the ScriptableObject asset in the resource folder
        string assetPath = resourceFolderPath + "/DummyAuthProvider.asset";
        AssetDatabase.CreateAsset(providerSettings, assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Default Cloud Provider created at: " + assetPath);
    }
}
