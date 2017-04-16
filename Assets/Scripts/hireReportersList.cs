using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UIManager;


public class HireReportersList : MonoBehaviour {
	public GameObject singleReporterPrefab;
	public GameObject singleReporterCV;

	public GameObject listLocation;


	mainGame mainGame;

	// Use this for initialization
	void Start () {
		
		mainGame = GameObject.FindObjectOfType<mainGame>();

		createList ();
		
	}
	

	public void createList(){
		//Clear all items
		int items = listLocation.transform.childCount - 1;
		for (int i = items; i >= 0; i--)
		{
			GameObject.Destroy(listLocation.transform.GetChild(i).gameObject);
		}
		int j = 0;
		foreach (reporter r in mainGame.reporters.reporters) {
			if (r.isHired == false) {

				GameObject listItem = Instantiate (singleReporterPrefab) as GameObject;

				listItem.transform.SetParent(listLocation.transform, false);

				listItem.transform.Find ("ReporterName").GetComponent<TextMeshProUGUI> ().text = r.firstName + " " + r.secondName + " (" + r.age + ")"; 
				//go.transform.Find ("Personality").GetComponent<Text> ().text = r.personality.name; 
				listItem.transform.Find ("Wage").GetComponent<TextMeshProUGUI> ().text = r.wage.ToString ("C"); 
				listItem.transform.Find ("Sources").GetComponent<TextMeshProUGUI> ().text = r.sources.ToString (); 
				listItem.transform.Find ("QualitySlider").GetComponent<Slider> ().value = (r.skills.integrity + r.skills.quality) / 2;
				listItem.GetComponent<Button>().onClick.AddListener(delegate{openCV(r);});

				r.myHireCard = listItem;
				//Make a new CV
				GameObject singleCV = (GameObject)Instantiate (singleReporterCV);

				singleCV.transform.SetParent(GameObject.Find("Canvas").transform, false);

				float xOffset = singleCV.transform.position.x;
				float yOffset = singleCV.transform.position.y;
				Vector3 cvNewPos = new Vector3 (xOffset + (10 * j) , yOffset + (10 * j) ,singleCV.transform.position.z);

				singleCV.transform.position = cvNewPos;

				singleCV.transform.Find ("ReporterName").GetComponent<TextMeshProUGUI> ().text = r.firstName + " " + r.secondName;
				singleCV.transform.Find ("Age").GetComponent<TextMeshProUGUI> ().text = r.age.ToString ();
				singleCV.transform.Find ("Gender").GetComponent<TextMeshProUGUI> ().text = r.gender.ToString();
				singleCV.transform.Find ("Wage").GetComponent<TextMeshProUGUI> ().text = r.wage.ToString("C");
				singleCV.transform.Find ("Personality").GetComponent<TextMeshProUGUI> ().text = r.mainPersonality.name;
				//this.transform.Find ("Tooltip").GetComponent<BoundTooltipTrigger> ().text = r.mainPersonality.description;
				singleCV.transform.Find ("SpeedSlider").GetComponent<Slider> ().value = r.skills.speed;
				singleCV.transform.Find ("LuckSlider").GetComponent<Slider> ().value = r.skills.luck;
				singleCV.transform.Find ("IqSlider").GetComponent<Slider> ().value = r.skills.iq;
				singleCV.transform.Find ("QualitySlider").GetComponent<Slider> ().value = r.skills.quality;
				singleCV.transform.Find ("IntegritySlider").GetComponent<Slider> ().value = r.skills.integrity;
				singleCV.transform.Find ("RightSlider").GetComponent<Slider> ().value = r.political.right;
				singleCV.transform.Find ("LeftSlider").GetComponent<Slider> ().value = r.political.left;

				foreach(topic t in r.allTopics.topics){

					switch (t.name)
					{
					case "finance":
						singleCV.transform.Find("Topics").FindChild("finance").GetComponentInChildren<Slider> ().value = t.xp;
						break;
					case "worldAffairs":
						singleCV.transform.Find("Topics").FindChild("worldAffairs").GetComponentInChildren<Slider> ().value = t.xp;
						break;
					case "politics":
						singleCV.transform.Find("Topics").FindChild("politics").GetComponentInChildren<Slider> ().value = t.xp;
						break;
					case "sports":
						singleCV.transform.Find("Topics").FindChild("sports").GetComponentInChildren<Slider> ().value = t.xp;
						break;
					case "entertainment":
						singleCV.transform.Find("Topics").FindChild("entertainment").GetComponentInChildren<Slider> ().value = t.xp;
						break;
					case "cultureArts":
						singleCV.transform.Find("Topics").FindChild("cultureArts").GetComponentInChildren<Slider> ().value = t.xp;
						break;
					case "scienceTechnology":
						singleCV.transform.Find("Topics").FindChild("scienceTechnology").GetComponentInChildren<Slider> ().value = t.xp;
						break;
					case "healthEducation":
						singleCV.transform.Find("Topics").FindChild("healthEducation").GetComponentInChildren<Slider> ().value = t.xp;
						break;
					default:
						break;
					}
				}

				singleCV.transform.Find ("HireButton").GetComponent<Button> ().onClick.AddListener(delegate{hireReporter(r);});

				singleCV.transform.Find ("Close").GetComponent<Button> ().onClick.AddListener(delegate{closeCV(r);});

				r.myCV = singleCV;

				j++;
			}
		}
		
	}

	public void hireReporter(reporter currentReporter){
		Debug.Log (currentReporter.firstName + " hire");

		currentReporter.hireMe ();
		mainGame.hiredReporters.Add (currentReporter);

		createList ();
	
		//StartCoroutine(commonHelpers.fadeInOut(currentReporter.myCV.GetComponent<CanvasGroup>()));

		/*
		currentReporter.reporterGO.transform.position = spawnZone.transform.position;
		GameObject go = (GameObject)Instantiate (currentReporter.reporterGO);
		//THIS NEEDS TO BE LIKE A FUCNTION
		go.GetComponent<reporterGameObject> ().r = currentReporter;
		*/

	}

	public void openCV(reporter currentReporter){
		currentReporter.myCV.SetActive (true);
		commonHelpers.BringToFront (currentReporter.myCV);
		StartCoroutine(commonHelpers.fadeInOut(currentReporter.myCV.GetComponent<CanvasGroup>(),
			delegate{}
		));
	}

	public void closeCV(reporter currentReporter){
		StartCoroutine(commonHelpers.fadeInOut(currentReporter.myCV.GetComponent<CanvasGroup>(),
			delegate{currentReporter.myCV.SetActive (false);}
		));
	}
		
}
