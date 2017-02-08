using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleReporterList : MonoBehaviour {

	public reporter selectedReporter;
	SingleReporterCV hireReporterScript;
	// Use this for initialization
	void Start () {
		hireReporterScript = GameObject.FindObjectOfType<SingleReporterCV>();
	
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void openCV(){

		Debug.Log (selectedReporter.firstName);


		//blur.SetActive (true);

		//GameObject.Find ("SingleReporterCV").SetActive(true);
		//hireReporterScript.currentReporter = selectedReporter;
	}
}
