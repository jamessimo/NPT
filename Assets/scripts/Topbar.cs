using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Topbar : MonoBehaviour {
	
	mainGame mainGame;

	// Use this for initialization
	void Start () {
		mainGame = GameObject.FindObjectOfType<mainGame>();

		transform.FindChild ("NewspaperZone").FindChild ("Newspaper").GetComponentInChildren<Text> ().text = mainGame.newsPaper.pNewspaper.newspaperName;
		transform.FindChild("Money").GetComponent<Text>().text = mainGame.newsPaper.pNewspaper.money.ToString ("N");
		transform.FindChild ("Audience").GetComponent<Text> ().text = mainGame.newsPaper.pNewspaper.readers.ToString("N0");

	}
}
