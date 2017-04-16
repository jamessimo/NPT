using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorizeSlider : MonoBehaviour {
	private Slider current;
	private Image currentFill;

	public Color lowColor = new Color (1, 0.4f, 0.4f);
	public Color midColor = new Color (1, 0.9f, 0.15f);
	public Color hiColor = new Color (0.4f, 1, 0.4f); 

	// Use this for initialization
	void Awake () {
		current = this.gameObject.GetComponent<Slider>();

		currentFill = current.transform.FindChild ("Fill Area").FindChild ("Fill").GetComponent<Image>();
		current.onValueChanged.AddListener (delegate {ValueChangeCheck ();});

		if (current.value < 0.33f) {
			currentFill.color = lowColor; 
		}  
		if (current.value > 0.33f) {
			currentFill.color = midColor; 
		}
		if (current.value > 0.66f) {
			currentFill.color = hiColor; 
		}

	}

	void Update (){


	}

	public void ValueChangeCheck(){
		
		if (current.value < 0.33f) {
			currentFill.color = lowColor; 
		}  
		if (current.value > 0.33f) {
			currentFill.color = midColor; 
		}
		if (current.value > 0.66f) {
			currentFill.color = hiColor; 
		}
	}



}
