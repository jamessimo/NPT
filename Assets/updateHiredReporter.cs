using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateHiredReporter : MonoBehaviour {

	public reporter r;

	// Use this for initialization
	void Start () {

	}
	void OnEnable()
	{			
		reporterGameObject.stateChanged += updateState;
	}
		
	void OnDisable()
	{
		reporterGameObject.stateChanged -= updateState;
	}

	void updateState(){
		this.transform.Find ("CurrentState").GetComponent<TextMeshProUGUI> ().text = r.currentState;
	}




}
