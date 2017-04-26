using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]                                                          
public class reporter {
    public enum Gender { Male, Female };
    public string firstName;
    public string secondName;
    public int age;
    public Gender gender;
	public Sprite avatar; 
    public basicSkills skills;

    public allTopics allTopics;
   
	public personality mainPersonality;
	public List<personality> otherPersonalities;

    public political political;

	[Range(0, 1f)] public float jobSatisfaction;
    public float wage;
	public int sources;
    public bool isHired;
    public bool isInJail;
    public bool isDead;
    public bool isSick;

	public bool isAtDesk;
	[Range(0, 1f)] public float progress;
    public story currentStory;
	public topic currentTopic;
    public GameObject reporterGO;

	public GameObject currentDesk;

	public GameObject myCV;
	public GameObject myHireCard;
	public GameObject myCard;

	public string currentState;


	public void init (){
		//Cleanup floats
	}
	public void hireMe (){
		this.isHired = true;
	}
}
