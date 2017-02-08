using System.Collections;
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
	[Range(0, 1f)] public float jobSatisfaction;
    public float wage;
	public int sources;
    public bool isHired;
    public bool isInJail;
    public bool isDead;
    public bool isSick;

	[Range(0, 100)] public int progress;
    public story currentStory;
	public topic currentTopic;
    public GameObject reporterGO;
	void init (){
		//Cleanup floats
	}
	void writeArticle (){
		Debug.Log (this.firstName);
	}
}
