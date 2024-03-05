using Studio23.SS2.AuthSystem.Data;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DummyAuthProviderEditor : MonoBehaviour
{
    [MenuItem("Studio-23/AuthSystem/Providers/DummyAuthAuthProvider", false, 10)]
    static void CreateDefaultProvider()
    {
        DummyAuthAuthProvider authProviderSettings = ScriptableObject.CreateInstance<DummyAuthAuthProvider>();

        // Create the resource folder path
        string resourceFolderPath = "Assets/Resources/AuthSystem/Providers";

        if (!Directory.Exists(resourceFolderPath))
        {
            Directory.CreateDirectory(resourceFolderPath);
        }

        // Create the ScriptableObject asset in the resource folder
        string assetPath = resourceFolderPath + "/DummyAuthProvider.asset";
        AssetDatabase.CreateAsset(authProviderSettings, assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Default Cloud Provider created at: " + assetPath);
    }
}
