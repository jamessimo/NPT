using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManager {

	public class commonHelpers : MonoBehaviour {
		
	 	public mainGame g;


		static public IEnumerator fadeInOut(CanvasGroup canvasGroup,System.Action<int>  callback)    {
			if (canvasGroup.alpha != 0) {
				while (canvasGroup.alpha > 0) {
					canvasGroup.alpha -= Time.unscaledDeltaTime * 2f;
					yield return new WaitForSecondsRealtime(0);
				}
			} else {
				while (canvasGroup.alpha < 1) {
					canvasGroup.alpha += Time.unscaledDeltaTime * 2f;
					yield return new WaitForSecondsRealtime(0);
				}
			}
			callback (0);
			Debug.Log ("done");
		}

		static private IEnumerator blurInOut(Material mat)    {
			float i = mat.GetFloat ("_Radius");
			while(i > 0){

				mat.SetFloat ("_Radius",i -= Time.deltaTime * 2f);
				yield return null;
			}
			Debug.Log ("done" + i);
		}

		private void blurOut(){
			//GameObject.Find ("SingleReporterCV").GetComponent<CanvasGroup> ().alpha = 0f;
			//StartCoroutine(fadeInOut(GameObject.Find ("SingleReporterCV").GetComponent<CanvasGroup>()));
			/*GameObject.Find ("Blurout").GetComponent<Image> ().material.SetInt ("_Radius",3);
		StartCoroutine(blurInOut(GameObject.Find ("Blurout").GetComponent<Image> ().material));
		*/
			//GameObject.Find ("Blurout").GetComponent<Image> ().raycastTarget = false;
		}

		static public void BringToFront(GameObject current) {
			current.transform.SetAsLastSibling ();
		}
	
	}

}
