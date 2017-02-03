using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class mainGame : MonoBehaviour {

	//public allTopics topics;
    public allReporters reporters;
	// Use this for initialization
	void Start () {

		//topics.entertainment.name = "hello";

		//reporters.reporters [0].allTopics;
//		reporters.reporters [0].currentStory.currentTopic = topics.entertainment;
		reporters.reporters [0].currentTopic = reporters.reporters [0].allTopics.finance;

		writeArticle (reporters.reporters [0]);

        //reporters.reporters[0].allTopics.entertainment.xp = 334;
//		Debug.Log(reporters.reporters[0].allTopics.cultureArts.xp);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
	void writeArticle (reporter r){
		r.currentStory = new story ();

	
		r.currentStory.storyTopic = r.currentTopic;

		Debug.Log (r.currentStory.storyTopic.name);

		r.currentStory.headline = "Random stuff";



	}
}
