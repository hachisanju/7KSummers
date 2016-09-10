using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class text_write : MonoBehaviour {

	public float letterPause = 0.1f;
	public int pause = 300;
	public AudioSource typesound;
	public AudioClip sfx;
	public bool can_write = false;
	public int scene = 0;
	public string dialogue = "";
	public bool done = false;
	public float timer = 5;

	string message;
	Text textComp;
	void Start(){
		typesound = GetComponent<AudioSource> ();
		sfx = Resources.Load<AudioClip> ("SFX/typesound.wav");
	}
	void Update(){
		if (can_write == true)
			write (dialogue);
		getscene ();
		if (done == true)
			fading ();
	}

	// Use this for initialization
	void write (string literal) {
		can_write = false;
		textComp = GetComponent<Text>();
		message = literal;
		textComp.text = "";
		StartCoroutine(TypeText ());

	}

	IEnumerator TypeText () {
		foreach (char letter in message.ToCharArray()) {
			System.Threading.Thread.Sleep (pause);
			textComp.text += letter;
			//if (typeSound1 && typeSound2)
			//	SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
			typesound.Play();
			yield return 0;

			//yield return new WaitForSeconds (letterPause);
		}
		if (scene == 10)
			done = true;
	}
	void getscene(){
		//Debug.Log ("Scene = " + scene + " and Real Scene = " + GameObject.FindObjectOfType<Text> ().GetComponent<timerscript> ().Scene);
		if (scene != GameObject.FindObjectOfType<Text> ().GetComponent<timerscript> ().Scene) {
			//Debug.Log ("yo");
			can_write = true;
			scene = GameObject.FindObjectOfType<Text> ().GetComponent<timerscript> ().Scene;
		}
		switch (scene) {
		case (1):
			dialogue = "Many years ago, a small group of travellers\nstumbled upon this very land.";
			break;
		case (2):
			dialogue = "They had been searching for a new home,\nand here, they decided they had found one.";
			break;
		case (3):
			dialogue = "The travellers set up a small camp,\nthat eventually flourished into a town.";
			break;
		case (4):
			dialogue = "But then one day, a tremendous storm\ndestroyed the homes of all of the people.";
			break;
		case (5):
			dialogue = "Heartbroken and unsure of how to continue,\nthe people turned their prayers to the skies.";
			break;
		case (6):
			dialogue = "In that moment, bathed in the moonlight, the\ncity was overtaken by a tremendous radiance.";
			break;
		case (7):
			dialogue = "The hands of time ground to a halt, then\nsuddenly began to turn backwards.";
			break;
		case (8):
			dialogue = "Once again, the storm approached, slowly\n threatening to destroy the city";
			break;
		case (9):
			dialogue = "But this time, the people were prepared, and could\nsave the things most precious to them.";
			break;
		case (10):
			dialogue = "And so the people of Stone Valley\naccepted the moon as their protector.";
			break;
		}
	}
	//GameObject.FindObjectOfType<timerscript>.GetComponent().scene
	void fading(){
		//Debug.Log ("hello");

		timer -= Time.deltaTime;

		if (timer <= 0) {
			Color c = GetComponent<Text> ().color;
			Debug.Log (c.a);
			c.a -= .22f;
			GetComponent<Text> ().color = c;
			timer +=0.3f;
			if (c.a < 0)
				SceneManager.LoadScene ("MenuScene");
		}
	}
}