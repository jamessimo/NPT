﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                                                          
public class reporter {
    public enum Gender { Male, Female };
    public string firstName;
    public string secondName;
    public int age;
    public Gender gender;
    public basicSkills skills;

    public allTopics allTopics;
   
    public personality personality;
    public political political;
    public int jobSatisfaction;
    public float wage;
    public int sources;
    public bool isHired;
    public bool isInJail;
    public bool isDead;
    public bool isSick;
    public int progress;
    public story currentStory;
    public GameObject reporterGO;
}