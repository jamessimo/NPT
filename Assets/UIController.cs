﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {
	
	mainGame g;

	public Sprite whiteTab;
	public Sprite canaryTab;

	public List<Image> reporterTabs; 

	public GameObject clockHourHand;

	// Use this for initialization
	void Start () {
		g = GameObject.FindObjectOfType<mainGame>();

		StartCoroutine (clockTick ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void changeTabReporters (Image currentTab){ 	//DUMB FIND CLICKED TAB 
		foreach(Image t in reporterTabs){
			t.overrideSprite = whiteTab;
		}
		currentTab.overrideSprite = canaryTab;
		currentTab.GetComponentInParent<CanvasGroup> ().transform.SetAsLastSibling ();
	}

	public void changeTabReporters (string tabName){	//PASS IN TAB ARG
		foreach(GameObject tab in GameObject.FindGameObjectsWithTag("Tab"))
		{
			tab.transform.FindChild ("TabBG").GetComponent<Image> ().overrideSprite = whiteTab;
			if (tab.GetComponentInChildren<TextMeshProUGUI> ().text == tabName) {
				tab.transform.FindChild ("TabBG").GetComponent<Image> ().overrideSprite = canaryTab;
				tab.GetComponentInParent<CanvasGroup> ().transform.SetAsLastSibling ();
			}
		}
	}

	public void pauseButton (){
		g.pauseGame ();
	}
	public void playButton (){
		g.unPauseGame ();
	}

	public IEnumerator clockTick()    {
		if (clockHourHand.transform.rotation.z > -359f) {
			float handRot = 0;
			while (clockHourHand.transform.rotation.z > -359f) {
				handRot -= 1f;
				clockHourHand.transform.localRotation = Quaternion.Euler(0,0,handRot);

				yield return new WaitForSeconds(0.1f);
			}
		} 
		Debug.Log ("END OF DAY");
	}

}
