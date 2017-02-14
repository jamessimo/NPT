using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class mainGame : MonoBehaviour {

	public allTopics masterTopicsList;
    public allReporters reporters;
	public List<reporter> hiredReporters;


	// Use this for initialization
	void Start () {

		init ();

		if (reporters.reporters [0].allTopics.topics.Count == 0) {
			reporters.reporters [0].allTopics = masterTopicsList;
		}
		//Debug.Log (masterTopicsList.topics.Find(x => x.name.Contains("sports")));

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
		blurOut();

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
		//build


	}
	public void sliderColorize(Slider s){
		Debug.Log (s.value);

		if (s.value < .25) {
		}
	}
	public void blurOut(){
		//GameObject.Find ("SingleReporterCV").GetComponent<CanvasGroup> ().alpha = 0f;
		//StartCoroutine(fadeInOut(GameObject.Find ("SingleReporterCV").GetComponent<CanvasGroup>()));

		/*GameObject.Find ("Blurout").GetComponent<Image> ().material.SetInt ("_Radius",3);

		StartCoroutine(blurInOut(GameObject.Find ("Blurout").GetComponent<Image> ().material));
		*/
		//GameObject.Find ("Blurout").GetComponent<Image> ().raycastTarget = false;

	}


	public IEnumerator fadeInOut(CanvasGroup canvasGroup)    {
		if (canvasGroup.alpha != 0) {
			while (canvasGroup.alpha > 0) {
				canvasGroup.alpha -= Time.deltaTime * 2f;
				yield return null;
			}
		} else {
			while (canvasGroup.alpha < 1) {
				canvasGroup.alpha += Time.deltaTime * 2f;
				yield return null;
			}
		}
	
		Debug.Log ("done");
	}

	private IEnumerator blurInOut(Material mat)    {
		float i = mat.GetFloat ("_Radius");
		while(i > 0){
			
			mat.SetFloat ("_Radius",i -= Time.deltaTime * 2f);
			yield return null;
		}
		Debug.Log ("done" + i);
	}
		


}
