using UnityEngine;
using System.Collections;

public class fadeout : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Animation>().Play("fadeout");
		GetComponent<Animation>().Play();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
