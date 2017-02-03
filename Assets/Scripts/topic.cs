using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class topic {
	public string name;
	[Range(0, 100)] public int xp;
    public bool enabled = true;

}
