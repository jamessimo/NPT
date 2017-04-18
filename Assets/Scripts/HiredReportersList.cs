using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HiredReportersList : MonoBehaviour {
	public GameObject singleHiredReporterUI;
	mainGame mainGame;

	 
	// Use this for initialization
	void Start () {
		mainGame = GameObject.FindObjectOfType<mainGame>();
		createList ();
	}
	


	public void createList(){

		//Clear all items
		int items = this.transform.childCount - 1;
		for (int i = items - 1; i > 0; i--)
		{
			GameObject.Destroy(this.transform.GetChild(i).gameObject);
		}

		foreach (reporter r in mainGame.reporters.reporters) {
			if (r.isHired == true) {
				
				GameObject go = (GameObject)Instantiate (singleHiredReporterUI);

				go.transform.SetParent (this.transform);
				go.transform.Find ("ReporterName").GetComponent<TextMeshProUGUI> ().text = r.firstName + " " + r.secondName + " (" + r.age + ")"; 
				go.transform.Find ("QualitySlider").GetComponent<Slider> ().value = (r.skills.integrity + r.skills.quality) / 2;;
				go.transform.Find ("HappySlider").GetComponent<Slider> ().value = r.jobSatisfaction;

				Dropdown ddTopics = go.transform.Find("TopicsDropdown").GetComponent<Dropdown>();



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
					if(r.currentTopic == null){
						r.reporterGO.GetComponent<reporterGameObject>().fsm.ChangeState(reporterGameObject.States.IdleAtDesk);
					}
				});

				//r.currentTopic = r.allTopics.topics [1];
			}
		}
	}

}
