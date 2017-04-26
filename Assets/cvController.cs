using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tween;

public class cvController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void moveLeft(){
	}
	public void moveRight(System.Action<bool>  callback){
		
		Vector3 startPos = this.transform.position;
		Vector3 midPos = new Vector3(10f,10f,0);
		Vector3 endPos = this.transform.position;

		this.gameObject.Tween("ShuffleRight", startPos, endPos, 1f, TweenScaleFunctions.CubicEaseIn, (t) =>
			{
				// progress
				this.transform.position = t.CurrentValue;

			}, (t) =>
			{
				// completion
				this.gameObject.Tween("ShuffleRight", startPos, midPos, 1f, TweenScaleFunctions.Linear, (t2) =>
					{
						// progress
						this.gameObject.transform.position = t2.CurrentValue;
					}, (t2) =>
					{
						// completion
						this.gameObject.Tween("ShuffleRight", midPos, endPos, 1f, TweenScaleFunctions.CubicEaseOut, (t3) =>
							{
								// progress
								this.gameObject.transform.position = t3.CurrentValue;
							}, (t3) =>
							{
								// completion - nothing more to do!
								callback(true);
							});
					});
			});
	}

}
