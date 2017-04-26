using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
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
			IdleAtDesk,
			WriteStory,
			DrinkAtDesk,
			StressAtDesk,
		LeaveDesk

	}

	public StateMachine<States> fsm;

	public delegate void stateChange();
	public static event stateChange stateChanged;

	// Use this for initialization
	void Start () {
		
		fsm = StateMachine<States>.Initialize(this, States.Idle);
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		g = GameObject.FindObjectOfType<mainGame>();

	}
	void Update () {
		

		if (r.currentState != fsm.State.ToString () && stateChanged != null)
		{
			r.currentState = fsm.State.ToString ();
			stateChanged();
		}

	}

	public void Idle_Enter(){

		//SET ANIMATION TO IDLE
		Debug.Log ("I am now idle");

	}

	public void Idle_Update(){
		//DO I OWN A DESK?

		if (g.fsm.State == mainGame.States.WritingMode) {
			
			if (hasDesk ()) {
				
				//WALK TO DESK
				fsm.ChangeState (States.GotoDesk);
			
			} else {
				
				//FIND A FREE DESK
				findDesk ();

			}
		}
	}

	public void GotoDesk_Enter(){
		//SET WALK ANIMATION
		this.agent.destination = r.currentDesk.transform.position; 
	}
	public void GotoDesk_Update(){
		float distance = Vector3.Distance (r.currentDesk.gameObject.transform.position, this.transform.position);

		if (distance < 1.7f) {
			fsm.ChangeState(States.SitAtDesk);
		}

	}

	public void SitAtDesk_Enter () {
		//SIT DOWN ANIMATION
		agent.Stop ();
		this.transform.GetComponent<CapsuleCollider> ().enabled = false;
		this.transform.position = r.currentDesk.transform.FindChild("Chair").transform.position;
		r.isAtDesk = true;
		r.currentDesk.GetComponent<desk>().currentReporter = r;
		r.currentDesk.GetComponent<desk>().currentTopic = r.currentTopic;
		r.currentDesk.GetComponent<desk> ().available = false;
	}

	public void SitAtDesk_Update () {
		//IF HAS NO SET TOPIC
		if (r.currentTopic == null || g.newsPaper.pNewspaper.progress >=1f) {
			//Idle at desk
			fsm.ChangeState(States.IdleAtDesk);
		}else{
			if (r.currentStory == null) {
				createNewStory ();
			}
			fsm.ChangeState(States.WriteStory);
		}
	}

	public void IdleAtDesk_Enter () {
		//IDLE AT DESK ANIMATION
		Debug.Log("I am idle AT DESK");
	}

	public void IdleAtDesk_Update () {
		if (r.currentTopic != null && g.newsPaper.pNewspaper.progress < 1f) {
			if (r.currentStory == null) {
				createNewStory ();
			}
			fsm.ChangeState(States.WriteStory);
		}
		//ANIMATION TO SHOW NOTHING TO DO!!!
	}
		
	public void createNewStory () {

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
		r.currentStory.political.left = r.political.left;
		r.currentStory.political.right = r.political.right;

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
	}
		
	public void WriteStory_Enter(){
		//SET WRITE ANIMATION	
	}

	public void WriteStory_Update(){

		//TODO add a sprite effect to r.reporterGO

		//FINISHED MY STORY
		if (r.progress >= 1f) {
			r.progress = 1f;
			//presentStory ();
		}

		//FINISHED BY STORY AND NEWSPAPER
		if (r.progress >= 1f && g.newsPaper.pNewspaper.progress >= 1f) {
			//SHOW STORY TO USER

			fsm.ChangeState(States.IdleAtDesk);
		}


		//ADD TO OWN STORY
		if (r.progress < 1f) {
			r.progress += r.skills.speed / 100;
			// Debug.Log ("Story progress: " + r.progress);
		}

		//ADD TO NEWSPAPER
		if (g.newsPaper.pNewspaper.progress < 1f) {
			if (r.progress >= 1f) {
				//REPORTER IS NOT ADDING TO HIS OWN STORY
				g.newsPaper.pNewspaper.progress += r.skills.speed / 400;
			} else {
				//REPORTER IS ADDING TO HIS OWN STORY
				g.newsPaper.pNewspaper.progress += r.skills.speed / 600;
			}
			//Debug.Log (g.newsPaper.pNewspaper.progress);

		}

	}

	public void draftAdd () {
		r.currentStory.draft += 1;
		if (r.currentStory.quality != 1) {
			r.currentStory.quality = (startSources * singleSource) + (singleSource * (r.currentStory.draft + r.skills.integrity));
			r.progress = 0; 
			fsm.ChangeState(States.WriteStory);
		} else {
			//TODO: DISABLE DRAFT BUTTON;
		}
	}

	public void presentStory (){

		//NEED PAGE SHOW ANIMATION

		GameObject storyPageUI = (GameObject)Instantiate (storyPage);


		storyPageUI.SetActive (true);

		storyPageUI.transform.Find ("AuthorName").GetComponent<TextMeshProUGUI> ().text = r.firstName + " " + r.secondName; 
		storyPageUI.transform.Find ("Draft").GetComponent<TextMeshProUGUI> ().text = r.currentStory.draft.ToString();
		storyPageUI.transform.Find ("Headline").GetComponent<TextMeshProUGUI> ().text = r.currentStory.headline;
		storyPageUI.transform.Find ("Topic").GetComponent<TextMeshProUGUI> ().text = r.currentStory.storyTopic.name;

		storyPageUI.transform.Find ("StoryQuality").GetComponent<Slider> ().value = r.currentStory.quality;
		storyPageUI.transform.Find ("StoryTrust").GetComponent<Slider> ().value = r.currentStory.trust;
		storyPageUI.transform.Find ("StoryLeft").GetComponent<Slider> ().value = r.currentStory.political.left;
		storyPageUI.transform.Find ("StoryRight").GetComponent<Slider> ().value = r.currentStory.political.right;

		storyPageUI.transform.Find ("EditButton").GetComponent<Button> ().onClick.AddListener(delegate{draftAdd();});
		storyPageUI.transform.Find ("PublishButton").GetComponent<Button> ().onClick.AddListener(delegate{publishStory();});
		storyPageUI.transform.Find ("RedoButton").GetComponent<Button> ().onClick.AddListener(delegate{redoStory();});

	}

	public bool hasDesk(){
		if (r.currentDesk == null) {
			r.isAtDesk = false;
			return false;
		} else {
			r.isAtDesk = true;
			return true;
		}
	}

	public void findDesk(){
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
		}
		if (r.currentDesk == null) {
			Debug.Log (r.firstName + " cant find a DESK");
		}
	}
	public void redoStory(){
		createNewStory ();
		fsm.ChangeState(States.WriteStory);
	}
	public void publishStory() {
		
		g.newsPaper.pNewspaper.todaysStory = r.currentStory;
	
		//PRINTER LOGIC
			// SET TODAYS STORY 
			// TELL ALL REPORTERS TO STOP MAKING STORIES
	}


	/*public IEnumerator writeStory() {
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
	}*/



}
