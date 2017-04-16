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
		if (hit.gameObject.GetComponent<reporterGameObject> ().r.currentDesk == this.gameObject) {
			hit.gameObject.GetComponent<reporterGameObject> ().sitAtDesk ();
		}
	}
}