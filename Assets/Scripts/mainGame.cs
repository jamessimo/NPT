using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class mainGame : MonoBehaviour {

	public allTopics masterTopicsList;
    public allReporters reporters;
	public List<reporter> hiredReporters;


	// Use this for initialization
	void Start () {

		init ();

		reporters.reporters [0].allTopics = masterTopicsList;

		Debug.Log (masterTopicsList.topics.Find(x => x.name.Contains("sports")));

	//	Debug.Log (masterTopicsList.topics.Find(reporters.reporters [0].allTopics.topics[2]));



		//reporters.reporters [0].currentTopic = masterTopicsList.topics.Contains(new topic ("sports",true));
		//reporters.reporters [0].allTopics.topics.Find(new topic{name = "finance"})
		//reporters.reporters [0].currentTopic = reporters.reporters [0].allTopics.finance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void init (){

		//hide blur
		GameObject.Find ("Blurout").SetActive(false);

		//Create All topics list
		masterTopicsList.topics.Add(new topic ("finance",true));
		masterTopicsList.topics.Add(new topic ("worldAffairs", true));
		masterTopicsList.topics.Add(new topic ("politics",true));
		masterTopicsList.topics.Add(new topic ("sports",true));
		masterTopicsList.topics.Add(new topic ("entertainment", true));
		masterTopicsList.topics.Add(new topic ("cultureArts", true));
		masterTopicsList.topics.Add(new topic ("scienceTechnology", true));
		masterTopicsList.topics.Add(new topic ("healthEducation", true));

		//build


	}
}
