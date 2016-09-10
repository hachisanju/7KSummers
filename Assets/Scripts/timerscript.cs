using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class timerscript : MonoBehaviour {
	public int verse = 980;
	public Stopwatch timer = new Stopwatch ();
	public int Scene = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine(SceneCounter ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator SceneCounter(){
		for (int i = 0; i < 10; i++) {
			Scene = i+1;
			gameObject.GetComponent<Text> ().text = "Scene " + i;
			yield return new WaitForSeconds(9.885f);
			//yield return 0;

		}
	}
}
