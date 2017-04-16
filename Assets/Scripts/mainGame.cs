using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


[System.Serializable]
public class mainGame : MonoBehaviour {

	public allTopics masterTopicsList;
    public allReporters reporters;
	public playerNewspaper newsPaper;


	public List<reporter> hiredReporters;
	public headlines HEADLINES;

	private ModalPanel modalPanel;

	void Awake () {
		modalPanel = ModalPanel.Instance();
	}

	// Use this for initialization
	void Start () {

		init ();

		string json;

		using (StreamReader r = new StreamReader("Assets/data/headlines.json")) 
		{
			json = r.ReadToEnd ();
		} 
		HEADLINES = JsonUtility.FromJson<headlines>(json);



		/*

		ModalPanelDetails modalPanelDetails = new ModalPanelDetails ();




		modalPanelDetails.question = "This is an announcement!\nIf you don't like it, shove off!";
		modalPanelDetails.button1Details = new EventButtonDetails ();
		modalPanelDetails.button1Details.buttonTitle = "Gotcha!";
		modalPanelDetails.button1Details.action = TestCancelFunction;

		modalPanelDetails.button2Details = new EventButtonDetails ();
		modalPanelDetails.button2Details.buttonTitle = "Wew lad!";
		modalPanelDetails.button2Details.action = TestCancelFunction;

		modalPanel.NewChoice (modalPanelDetails);
*/


		//Loop through all reporter hired reporters  
		//Place them back in the scene
		//Tell them all to start writing


	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void init (){


		foreach (reporter r in reporters.reporters) {
			if (r.isHired == true) {
				GameObject go = (GameObject)Instantiate (r.reporterGO);
				go.GetComponent<reporterGameObject> ().r = r;
				//Find desk
			}

		}
		//hide blur
		//Create All topics list
		/*masterTopicsList.topics.Add(new topic ("finance",true));
		masterTopicsList.topics.Add(new topic ("worldAffairs", true));
		masterTopicsList.topics.Add(new topic ("politics",true));
		masterTopicsList.topics.Add(new topic ("sports",true));
		masterTopicsList.topics.Add(new topic ("entertainment", true));
		masterTopicsList.topics.Add(new topic ("cultureArts", true));
		masterTopicsList.topics.Add(new topic ("scienceTechnology", true));
		masterTopicsList.topics.Add(new topic ("healthEducation", true));
		*/

	}
	public void pauseGame(){
		Time.timeScale = 0;
	}

	public void unPauseGame(){
		Time.timeScale = 1;
	}
		
	void TestYesFunction () {
		Debug.Log ("Yes");
	}

	void TestNoFunction () {
		Debug.Log ("No");
	}

	void TestCancelFunction () {
		Debug.Log ("Cancel I guess");
	}


}
