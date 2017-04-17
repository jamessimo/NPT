using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StateMachine;

public class reporterGameObject : MonoBehaviour {
	public reporter r;
	public mainGame g;
	public GameObject[] desks;

	public GameObject aboutPage;
	public GameObject storyPage;

	public float singleSource;
	public float TotalQuality;
	public float startSources;

	public float[] draftPower;

	public NavMeshAgent agent;
	public Animator anim;


	public enum States
	{
		Idle,
		GotoDesk,
		SitAtDesk,
		WriteStory

	}
	public StateMachine<States> fsm;



	// Use this for initialization
	void Start () {


		fsm = StateMachine<States>.Initialize(this, States.Idle);

		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		g = GameObject.FindObjectOfType<mainGame>();

	}
	
	// Update is called once per frame

	/*void Update () {
		if (r.currentDesk == null) {
			desks = GameObject.FindGameObjectsWithTag ("Desk");
			foreach (GameObject d in desks) {
				if (d.GetComponent<desk> ().available == true) {
					d.GetComponent<desk> ().currentReporter = r;
					r.currentDesk = d;
					d.GetComponent<desk> ().available = false;
					d.GetComponent<desk> ().currentTopic = r.currentTopic;
					return;
				}
			}
		} else {

			//Update empty desk with reporter info
			//r.currentDesk.GetComponent<desk>().currentReporter = r;
			//r.currentDesk.GetComponent<desk>().currentTopic = r.currentTopic;
		}

		if (r.currentDesk == null) {
			Debug.Log (r.firstName + " has no desk!");
		} 


		//If at desk and has a story
		if (r.isAtDesk == true && r.currentStory.headline != null ) {
			//writeStory ();
		}

		//Does reporter have a story to write? 

	}*/



	public void Idle_Enter(){

		//SET ANIMATION TO IDLE

		Debug.Log ("I am now idle");

	}

	public void Idle_Update(){
		Debug.Log ("I am waitng idle");
		//fsm.ChangeState(States.Idle);


	}

	public void GotoDesk_Enter(){
		
		//this.anim.SetTrigger ("Walk");

		//Find desk 


		this.agent.destination = r.currentDesk.transform.position; 
	}
	public void GotoDesk_Update(){
		
	}

	public void SitAtDesk_Enter () {
		agent.Stop ();
	
		this.transform.GetComponent<CapsuleCollider> ().enabled = false;

		this.transform.position = r.currentDesk.transform.FindChild("Chair").transform.position;


		r.isAtDesk = true;
		r.currentDesk.GetComponent<desk>().currentReporter = r;

		r.currentDesk.GetComponent<desk>().currentTopic = r.currentTopic;
		r.currentDesk.GetComponent<desk> ().available = false;

		startWriting ();

	}
		
	public void startWriting () {

		if (r.isAtDesk == false) {
			Debug.Log (r.firstName + " is not at desk");
			return;
		}

		//Create a new story
		r.currentStory = new story ();
		r.currentStory.headline = "This should be a random headline";
		r.currentStory.storyTopic = r.currentTopic;
		r.currentStory.draft = 1;
		r.progress = 0;

		
		TotalQuality = (r.skills.quality + r.currentTopic.xp) / 2;
		startSources =  r.sources * r.skills.integrity;
		singleSource = TotalQuality / r.sources;

		r.currentStory.quality = (startSources * singleSource) + (r.sources * (r.currentStory.draft + r.skills.integrity));
		r.currentStory.trust = r.skills.integrity; //NEEDS EDIT

		//r.currentStory.political.left = r.political.left;
		//r.currentStory.political.right = r.political.right;

		switch (r.currentStory.storyTopic.name)
			{
			case "finance":
				r.currentStory.headline = g.HEADLINES.finance[Random.Range (0, g.HEADLINES.finance.Count)];
				break;
			case "worldAffairs":
				r.currentStory.headline = g.HEADLINES.worldAffairs[Random.Range (0, g.HEADLINES.worldAffairs.Count)];
				break;
			case "politics":
				r.currentStory.headline = g.HEADLINES.politics[Random.Range (0, g.HEADLINES.politics.Count)];
				break;
			case "sports":
				r.currentStory.headline = g.HEADLINES.sports[Random.Range (0, g.HEADLINES.sports.Count)];
				break;
			case "entertainment":
				r.currentStory.headline = g.HEADLINES.entertainment[Random.Range (0, g.HEADLINES.entertainment.Count)];
				break;
			case "cultureArts":
				r.currentStory.headline = g.HEADLINES.cultureArts[Random.Range (0, g.HEADLINES.cultureArts.Count)];
				break;
			case "scienceTechnology":
				r.currentStory.headline = g.HEADLINES.scienceTechnology[Random.Range (0, g.HEADLINES.scienceTechnology.Count)];
				break;
			case "healthEducation":
				r.currentStory.headline = g.HEADLINES.healthEducation[Random.Range (0, g.HEADLINES.healthEducation.Count)];
				break;
			default:
				break;
			}


		StartCoroutine(writeStory());
		//Make sure reporter is at desk 

		//Set state to "Writing"

	}

	public void draftAdd () {
		r.currentStory.draft += 1;
		if (r.currentStory.quality != 1) {
			r.currentStory.quality = (startSources * singleSource) + (singleSource * (r.currentStory.draft + r.skills.integrity));
		} else {
			//TODO: DISABLE DRAFT BUTTON;
		}
	}

	public void presentStory (){

		// Create instence of a story 
		// populate vars 
		// show panel 
		// animate sliders
	}

	public IEnumerator writeStory() {
		if (r.progress < 1) {
			while (r.progress < 1 ) {

				if (r.isAtDesk == true) {
					r.progress += r.skills.speed / 10;
					//TODO add a sprite effect to r.reporterGO
					Debug.Log ("Story progress: " + r.progress);

					yield return new WaitForSeconds(1);
				} else {
					yield return null;
				}

			}
		} 

		Debug.Log ("Story done");
		presentStory ();
	}



}
