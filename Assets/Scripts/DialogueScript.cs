using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {
	public GameObject referencetext;
	public Text display;
	void OnTriggerEnter2D(Collider2D other){
		referencetext = GameObject.Find ("referencetext");
		display = referencetext.GetComponent<Text>();
		if (other.name == "Taylor") {
			display.text = "Big Man:\n 'Hey...I got fired from the public library.'";
			Debug.Log ("hey!");
		}
		/*while (other) {*/
			
		//}*/
	}
	void OnTriggerStay2D(Collider2D other){
		if (Input.GetKey ("'"))
			Debug.Log ("I got fired from the public library!");
	}
	void OnTriggerExit2D(Collider2D other){
		//referencetext.text = "";
	}

}