using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class newspaper {
    public string newspaperName;
	public DateTime startDate;
    public political political;
    public int readers;
    public float money;
    public float price;
    public int style;
    public int rank;
	[Range(-1f, 1f)] public float integrity;
    public story todaysStory;
    public List<story> history;

	[Range(0, 1f)] public float progress;
}
