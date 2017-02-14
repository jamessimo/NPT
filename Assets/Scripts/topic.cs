using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class topic {
	public string name;
	[Range(0f, 1f)] public float xp;
    public bool enabled;

	public topic(string n, bool en)
	{
		name = n;

		enabled = en;
	}

}
