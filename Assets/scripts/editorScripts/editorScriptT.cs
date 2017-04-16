using UnityEngine;
using System.Collections;
using UnityEditor;

public class editorScriptT
{
 	[MenuItem("Assets/Create/playerNewspaper")]
	public static playerNewspaper Create()
    {
		playerNewspaper assetB = ScriptableObject.CreateInstance<playerNewspaper>();

		AssetDatabase.CreateAsset(assetB, "Assets/playerNewspaper.asset");
        AssetDatabase.SaveAssets();
		return assetB;

    }
}