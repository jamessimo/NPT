using UnityEngine;
using System.Collections;
using UnityEditor;

public class editorScript
{
    [MenuItem("Assets/Create/Reporters List")]
    public static allReporters Create()
    {
        allReporters asset = ScriptableObject.CreateInstance<allReporters>();

        AssetDatabase.CreateAsset(asset, "Assets/allReporters.asset");
        AssetDatabase.SaveAssets();
        return asset;

    }
}