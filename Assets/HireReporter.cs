using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireReporter : MonoBehaviour {
	public reporter currentReporter;
//	public GameObject maingame = GameObject.Find("scriptbox").GetComponent<mainGame>();
	SingleReporterCV hireReporterScript;


	// Use this for initialization
	void Start () {
		hireReporterScript = GameObject.FindObjectOfType<SingleReporterCV>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void openCV () {

		//hireReporterScript.hireReporter (currentReporter);


		/*Debug.Log (currentReporter.firstName);

		//SingleReporterCV.
		currentReporter.isHired = true;
		mainGame.hiredReporters.Add (currentReporter);
		Destroy (this.gameObject);
		*/
		//Show single reporter screen

		//set single reporter view with data 


	}
}
