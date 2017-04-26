using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HiredReportersList : MonoBehaviour {
	
	public GameObject singleHiredReporterUI;
	public GameObject listLocation;

	mainGame mainGame;


	// Use this for initialization
	void Start () {
		mainGame = GameObject.FindObjectOfType<mainGame>();
		createList ();
	}

	void OnEnable()
	{			
		mainGame.reportersChanged += createList;
	}

	void OnDisable()
	{
		mainGame.reportersChanged -= createList;
	}

	public void createList(){

		//Clear all items
		foreach (Transform child in listLocation.transform) {			
			Destroy(child.gameObject);
		}
			
		foreach (reporter r in mainGame.hiredReporters) {

			GameObject hiredReporterUI = (GameObject)Instantiate (singleHiredReporterUI);

			hiredReporterUI.transform.SetParent(listLocation.transform, false);

			hiredReporterUI.GetComponent<updateHiredReporter> ().r = r;
			
			hiredReporterUI.transform.Find ("ReporterName").GetComponent<TextMeshProUGUI> ().text = r.firstName + " " + r.secondName + " (" + r.age + ")"; 
			hiredReporterUI.transform.Find ("QualitySlider").GetComponent<Slider> ().value = (r.skills.integrity + r.skills.quality) / 2;
			hiredReporterUI.transform.Find ("HappySlider").GetComponent<Slider> ().value = r.jobSatisfaction;
			hiredReporterUI.transform.Find ("PhotoBG").FindChild("Photo").GetComponent<Image> ().sprite = r.avatar;


			hiredReporterUI.transform.Find ("CurrentState").GetComponent<TextMeshProUGUI> ().text = r.currentState;


	
		//r.reporterGO.GetComponent<reporterGameObject>().stateChanged += delegate {VariableChangeHandler();};


			Dropdown ddTopics = hiredReporterUI.transform.Find("TopicsDropdown").GetComponent<Dropdown>();

			foreach(topic t in r.allTopics.topics)
			{
				switch (t.name)
				{
				case "finance":

					ddTopics.options.Add(new Dropdown.OptionData("Finance"));
					break;
				case "worldAffairs":
					ddTopics.options.Add(new Dropdown.OptionData("World Affairs"));

					break;
				case "politics":
					ddTopics.options.Add(new Dropdown.OptionData("Politics"));

					break;
				case "sports":
					ddTopics.options.Add(new Dropdown.OptionData("Sports"));

					break;
				case "entertainment":
					ddTopics.options.Add(new Dropdown.OptionData("Entertainment"));

					break;
				case "cultureArts":
					ddTopics.options.Add(new Dropdown.OptionData("Arts & Culture"));

					break;
				case "scienceTechnology":
					ddTopics.options.Add(new Dropdown.OptionData("Science & Technology"));

					break;
				case "healthEducation":
					ddTopics.options.Add(new Dropdown.OptionData("Health & Education"));

					break;
				default:
					break;
				}

			}
				
			if (r.currentTopic != null) {
				//Loop all topics and match dd i
				for (int i = 0; i < r.allTopics.topics.Count; i++) {
					if (r.currentTopic.name == r.allTopics.topics [i].name) {
						ddTopics.value = i;
						ddTopics.Select();
						ddTopics.RefreshShownValue();
					}
				}
			}

			ddTopics.onValueChanged.AddListener(delegate {
				r.currentTopic = r.allTopics.topics[ddTopics.value];
			});



			//r.currentTopic = r.allTopics.topics [1];
		}

	}

}
