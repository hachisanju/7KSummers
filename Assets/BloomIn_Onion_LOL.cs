using UnityEngine;
using System.Collections;

public class BloomIn_Onion_LOL : MonoBehaviour {
	public float timer = 0.05f;

	// Use this for initialization
	void Start () {
		GetComponent<UnityStandardAssets.ImageEffects.Bloom> ().bloomThreshold = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		/*for (GetComponent<UnityStandardAssets.ImageEffects.Bloom> ().bloomThreshold = 0.0f;
			GetComponent<UnityStandardAssets.ImageEffects.Bloom> ().bloomThreshold < .75f;
			GetComponent<UnityStandardAssets.ImageEffects.Bloom> ().bloomThreshold += 0.01f) {
			*/
			Debug.Log (GetComponent<UnityStandardAssets.ImageEffects.Bloom> ().bloomThreshold);
		//}
	//	while (GetComponent<UnityStandardAssets.ImageEffects.Bloom> ().bloomThreshold < .75f) {
		if (timer <= 0 && GetComponent<UnityStandardAssets.ImageEffects.Bloom> ().bloomThreshold < .75f) {
				reduce_threshold ();
				timer +=0.05f;
				}
		//	}
	}

	void reduce_threshold(){
		GetComponent<UnityStandardAssets.ImageEffects.Bloom> ().bloomThreshold += 0.02f;
	}
}
