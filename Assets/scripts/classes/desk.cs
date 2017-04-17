using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class desk : MonoBehaviour {
	public bool available;
	public reporter currentReporter;
	public topic currentTopic;

	//-------
	public GameObject writingtool;
	public GameObject lamp;
	public GameObject chair;
	public GameObject papers;

	void OnTriggerEnter(Collider hit){

		reporterGameObject hitReporter = hit.gameObject.GetComponent<reporterGameObject> ();

		if (hitReporter.r.currentDesk == this.gameObject) {
			hitReporter.fsm.ChangeState(hitReporter.States.SitAtDesk);
		}
	}
}