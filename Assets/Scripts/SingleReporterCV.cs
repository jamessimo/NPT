using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class SingleReporterCV : MonoBehaviour {
	
	private reporter currentReporter;
	mainGame mainGame;

	private hireReportersList hrList;

	private HiredReportersList hiredReportersScript;

	// Use this for initialization
	void Start () {
		mainGame = GameObject.FindObjectOfType<mainGame>();

		hiredReportersScript = GameObject.FindObjectOfType<HiredReportersList>();


		hrList = GameObject.FindObjectOfType<hireReportersList>();
		//GameObject.Find ("SingleReporterCV").GetComponent<CanvasGroup> ().alpha = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void populateCV(reporter r){
		currentReporter = r;

		this.transform.Find ("ReporterName").GetComponent<Text> ().text = currentReporter.firstName + " " + currentReporter.secondName;
		this.transform.Find ("Age").GetComponent<Text> ().text = currentReporter.age.ToString ();
		this.transform.Find ("Gender").GetComponent<Text> ().text = currentReporter.gender.ToString();
		this.transform.Find ("Wage").GetComponent<Text> ().text = currentReporter.wage.ToString("C");
		this.transform.Find ("Personality").GetComponent<Text> ().text = currentReporter.personality.name;
		this.transform.Find ("SpeedSlider").GetComponent<Slider> ().value = currentReporter.skills.speed;
		this.transform.Find ("LuckSlider").GetComponent<Slider> ().value = currentReporter.skills.luck;
		this.transform.Find ("IqSlider").GetComponent<Slider> ().value = currentReporter.skills.iq;

		this.transform.Find ("QualitySlider").GetComponent<Slider> ().value = currentReporter.skills.quality;
		this.transform.Find ("IntegritySlider").GetComponent<Slider> ().value = currentReporter.skills.integrity;
		this.transform.Find ("RightSlider").GetComponent<Slider> ().value = currentReporter.political.right;
		this.transform.Find ("LeftSlider").GetComponent<Slider> ().value = currentReporter.political.left;


		this.transform.Find ("Personality").GetComponent<BoundTooltipTrigger> ().text = "Booaloo";


		foreach(topic t in currentReporter.allTopics.topics){

			switch (t.name)
			{
			case "finance":

		
				this.transform.Find("Topics").FindChild("finance").GetComponentInChildren<Slider> ().value = t.xp;

				break;
			case "worldAffairs":
				this.transform.Find("Topics").FindChild("worldAffairs").GetComponentInChildren<Slider> ().value = t.xp;

				break;
			case "politics":
				this.transform.Find("Topics").FindChild("politics").GetComponentInChildren<Slider> ().value = t.xp;

				break;
			case "sports":
				this.transform.Find("Topics").FindChild("sports").GetComponentInChildren<Slider> ().value = t.xp;

				break;
			case "entertainment":
				this.transform.Find("Topics").FindChild("entertainment").GetComponentInChildren<Slider> ().value = t.xp;

				break;
			case "cultureArts":
				this.transform.Find("Topics").FindChild("cultureArts").GetComponentInChildren<Slider> ().value = t.xp;

				break;
			case "scienceTechnology":
				this.transform.Find("Topics").FindChild("scienceTechnology").GetComponentInChildren<Slider> ().value = t.xp;

				break;
			case "healthEducation":
				this.transform.Find("Topics").FindChild("healthEducation").GetComponentInChildren<Slider> ().value = t.xp;

				break;
			default:
				break;
			}


	
		}

	}

	public void hireReporter () {
		Debug.Log (currentReporter.firstName + " hire");

		currentReporter.hireMe ();
		mainGame.hiredReporters.Add (currentReporter);

		hrList.createList ();
		StartCoroutine(mainGame.fadeInOut(GameObject.Find ("SingleReporterCV").GetComponent<CanvasGroup>()));

		GameObject go = (GameObject)Instantiate (currentReporter.reporterGO);
		go.GetComponent<reporterGameObject> ().r = currentReporter;

		hiredReportersScript.createList ();
		//Trigger event to tell other script to update
	}

	public void closeWindow () {
		StartCoroutine(mainGame.fadeInOut(GameObject.Find ("SingleReporterCV").GetComponent<CanvasGroup>()));
	}
}
