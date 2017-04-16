using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class audience {
	public int size;
	public allTopics topics;
	public political politcal;
	public float averageSpend;
	[Range(-1f, 1f)] public float trust;
	[Range(-1f, 1f)] public float expectedIntegrity;
	[Range(-1f, 1f)] public float expectedQuality;
}
