using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UIManager;
using Tween;


public class HireReportersList : MonoBehaviour {
	public GameObject singleReporterPrefab;
	public GameObject singleReporterCV;

	public GameObject listLocation;

	public GameObject[] CVs;

	public List<reporter> reporterCVs;

	UIController UIController;

	HiredReportersList hiredReporterScript;

	mainGame mainGame;

	// Use this for initialization
	void Start () {
		
		mainGame = GameObject.FindObjectOfType<mainGame>();
		UIController = GameObject.FindObjectOfType<UIController> ();
		hiredReporterScript = GameObject.FindObjectOfType<HiredReportersList> ();
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
		CVs = GameObject.FindGameObjectsWithTag ("CV");
		foreach (GameObject cv in CVs) {
			Destroy(cv.gameObject);
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

				singleCV.transform.Find ("Image").GetComponent<Image> ().sprite = r.avatar;

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

				r.myCV.SetActive (false);

				j++;
			}
		}
	}


	public void hireReporter(reporter currentReporter){


		GameObject hiredTempCard = (GameObject)Instantiate (hiredReporterScript.singleHiredReporterUI);
		GameObject currentCV = currentReporter.myCV.gameObject;

		hiredTempCard.transform.SetParent(hiredReporterScript.listLocation.transform,false);
		hiredTempCard.GetComponent<CanvasGroup> ().alpha = 1;

		Vector3 startPos = currentCV.transform.position;
		Vector3 endPos = hiredTempCard.transform.position;

		endPos = hiredTempCard.GetComponent<RectTransform> ().position;
				
		UIController.changeTabReporters ("CURRENT");

		currentCV.gameObject.Tween("SlideRight", startPos, endPos, 1f, TweenScaleFunctions.CubicEaseIn, (t) =>
		{
			// progress
			currentCV.transform.localScale = new Vector3(1,1-t.CurrentProgress,1-t.CurrentProgress);
				//currentCV.GetComponent<RectTransform>().rect.height;
			currentCV.transform.position = t.CurrentValue;
			
		}, (t) =>
		{
			//Finished
			currentReporter.hireMe ();
			mainGame.hiredReporters.Add (currentReporter);


			currentReporter.reporterGO.transform.position = mainGame.spawnZone.transform.position;
			GameObject go = (GameObject)Instantiate (currentReporter.reporterGO);
			go.GetComponent<reporterGameObject> ().r = currentReporter;
		});
	}
	
	private IEnumerator DEPhireReporter(reporter currentReporter){

		float overTime = 1f;
		float startTime = Time.time;
		float scale = 1;

		GameObject hiredTempCard = (GameObject)Instantiate (hiredReporterScript.singleHiredReporterUI);

		hiredTempCard.transform.SetParent(hiredReporterScript.listLocation.transform, false);
		hiredTempCard.GetComponent<CanvasGroup> ().alpha = 1;

		Vector3 source = currentReporter.myCV.transform.position;
		Vector3 target = hiredTempCard.transform.position;

		UIController.changeTabReporters ("CURRENT");

		while(Time.time < startTime + overTime)
		{
			currentReporter.myCV.transform.localScale = new Vector3 (scale, scale, scale);
			currentReporter.myCV.transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
			scale = 1 - (Time.time - startTime)/overTime;
			yield return null;
		}

		//currentReporter.myCV.transform.position = target;
		//THIS NEEDS TO BE LIKE A FUCNTION

		currentReporter.hireMe ();
		mainGame.hiredReporters.Add (currentReporter);


		currentReporter.reporterGO.transform.position = mainGame.spawnZone.transform.position;
		GameObject go = (GameObject)Instantiate (currentReporter.reporterGO);
		go.GetComponent<reporterGameObject> ().r = currentReporter;

	

	}

	public void openCV(reporter currentReporter){

		//Show all CV's
		reporterCVs.Clear();

		reporterCVs.Add (currentReporter);

		foreach (reporter r in mainGame.reporters.reporters) {
			if (r.isHired == false && r != currentReporter) {
				r.myCV.SetActive (true);
				reporterCVs.Add (r);
			}
		}

		commonHelpers.BringToFront (currentReporter.myCV);

		GameObject.Find ("NextCVRight").GetComponent<Button> ().onClick.AddListener (delegate {
			currentReporter.myCV.GetComponent<cvController> ().moveRight (delegate {
				commonHelpers.BringToBack (currentReporter.myCV);
				Debug.Log(GameObject.FindGameObjectWithTag("CV").transform.Find("ReporterName").GetComponent<TextMeshProUGUI> ().text);

				openCV(reporterCVs[1]);

			});
		});

		/*StartCoroutine(commonHelpers.fadeInOut(currentReporter.myCV.GetComponent<CanvasGroup>(),
			delegate{}
		));*/
	}

	public void closeCV(reporter currentReporter){
		//Show all CV's

		foreach (reporter r in mainGame.reporters.reporters) {
			if (r.isHired == false) {
				r.myCV.SetActive (false);
			}
		}
		/*StartCoroutine(commonHelpers.fadeInOut(currentReporter.myCV.GetComponent<CanvasGroup>(),
			delegate{currentReporter.myCV.SetActive (false);}
		));*/
	}
		
}
