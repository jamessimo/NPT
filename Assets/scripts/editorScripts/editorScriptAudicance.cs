using UnityEngine;
using System.Collections;
using UnityEditor;

public class editorScriptAudicance
{
	[MenuItem("Assets/Create/playerAudience")]
	public static playerAudience Create()
    {
		playerAudience assetB = ScriptableObject.CreateInstance<playerAudience>();

		AssetDatabase.CreateAsset(assetB, "Assets/playerAudience.asset");
        AssetDatabase.SaveAssets();
		return assetB;

    }
}