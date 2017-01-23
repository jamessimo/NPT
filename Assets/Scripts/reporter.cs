using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                                                          
public class reporter {
    public enum Gender { Male, Female };
    public string firstName = "New";
    public string secondName = "Reporter";
    public Gender gender;

    public allTopics allTopics;
    public personality personality;
    public political political;
    public int jobSatisfaction;
    public float wage;
    public int sources;
}
