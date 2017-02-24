using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleReporterList : MonoBehaviour {

	public reporter selectedReporter;
	public SingleReporterCV hireReporterScript;
	private GameObject blur;
	private GameObject cvWindow;

	mainGame mainGame;


	// Use this for initialization
	void Start () {
		mainGame = GameObject.FindObjectOfType<mainGame>();

		hireReporterScript = GameObject.FindObjectOfType<SingleReporterCV>();
		cvWindow = GameObject.Find ("SingleReporterCV");

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void openCV(){

		//Debug.Log (selectedReporter.firstName);
		//GameObject.Find ("SingleReporterCV").SetActive(true);

		GameObject.Find ("SingleReporterCV").GetComponent<CanvasGroup> ().alpha = 0f;
		//GameObject.Find ("Blurout").GetComponent<CanvasGroup> ().alpha = 1f;

		hireReporterScript.populateCV (selectedReporter);
		StartCoroutine(mainGame.fadeInOut(GameObject.Find ("SingleReporterCV").GetComponent<CanvasGroup>()));

		//cvWindow.SetActive (true);
		//GameObject.Find ("Blurout").SetActive(true);

		//hireReporterScript.currentReporter = selectedReporter;
	}
}
