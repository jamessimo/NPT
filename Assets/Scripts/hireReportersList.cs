﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hireReportersList : MonoBehaviour {
	public GameObject singleReporterPrefab;

	mainGame mainGame;

	// Use this for initialization
	void Start () {
		
		mainGame = GameObject.FindObjectOfType<mainGame>();
		createList ();
		
	}
	

	public void createList(){

	
		//Clear all items
		int items = this.transform.childCount;
		for (int i = items - 1; i > 0; i--)
		{
			GameObject.Destroy(this.transform.GetChild(i).gameObject);
		}

		foreach (reporter r in mainGame.reporters.reporters) {
			if (r.isHired == false) {
				GameObject go = (GameObject)Instantiate (singleReporterPrefab);

				go.GetComponent<SingleReporterList> ().selectedReporter = r;

				go.transform.SetParent (this.transform);
				go.transform.Find ("ReporterName").GetComponent<Text> ().text = r.firstName + " " + r.secondName + " (" + r.age + ")"; 
				go.transform.Find ("Personality").GetComponent<Text> ().text = r.personality.name; 
				go.transform.Find ("Wage").GetComponent<Text> ().text = r.wage.ToString ("C"); 
				go.transform.Find ("Sources").GetComponent<Text> ().text = r.sources.ToString (); 
				go.transform.Find ("QualitySlider").GetComponent<Slider> ().value = r.skills.quality;
			}
		}
		
	}
		
}