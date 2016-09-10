using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class openingtimer : MonoBehaviour {
	public int verse = 980;
	public Stopwatch timer = new Stopwatch ();
	public int Scene = 0;
	public Sprite[] scenes;

	// Use this for initialization
	void Start () {
		scenes = new Sprite[10];

		scenes [0] = Resources.Load<Sprite> ("General_Sprites/Opening1");
		scenes [1] = Resources.Load<Sprite> ("General_Sprites/Opening2");
		scenes [2] = Resources.Load<Sprite> ("General_Sprites/Opening3");
		scenes [3] = Resources.Load<Sprite> ("General_Sprites/Opening4");
		StartCoroutine(SceneCounter ());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator SceneCounter(){
		for (int i = 0; i < 10; i++) {
			GetComponent<Image> ().sprite = scenes[i];
			yield return new WaitForSeconds(9.885f);

			//yield return 0;

		}
	}
}
