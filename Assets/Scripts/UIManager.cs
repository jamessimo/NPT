using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Sprite whiteTab;
	public Sprite canaryTab;

	public List<Image> reporterTabs; 

	// Use this for initialization
	void Start () {
		//SET DEFAULT PANEL 
	}

	public void changeTabReporters (Image currentTab){

		foreach(Image t in reporterTabs){
			t.overrideSprite = whiteTab;
		}
		currentTab.overrideSprite = canaryTab;
		currentTab.GetComponentInParent<CanvasGroup> ().transform.SetAsLastSibling ();

	}

}
