using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class newspaper {
    public string newspaperName;
    public Time startDate;
    public political political;
    public int readers;
    public float money;
    public float price;
    public int style;
    public int rank;
    public int integrity;
    public story todaysStory;
    public List<story> history;
}
