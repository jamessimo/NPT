using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleReporterCV : MonoBehaviour {
	
	public reporter currentReporter;
	mainGame mainGame;

	// Use this for initialization
	void Start () {
		mainGame = GameObject.FindObjectOfType<mainGame>();

		GameObject.Find ("SingleReporterCV").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void hireReporter () {
		Debug.Log (currentReporter.firstName);

		currentReporter.isHired = true;
		mainGame.hiredReporters.Add (currentReporter);
		//Destroy (this.gameObject);
		//Show single reporter screen

		//set single reporter view with data 


	}
}
