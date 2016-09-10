using UnityEngine;
using System.Collections;

public class LayerChanger : MonoBehaviour {

	private SpriteRenderer sprite;


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other.gameObject.layer);
	}

	void OnTriggerExit2D(Collider2D other){

		sprite = other.GetComponent<SpriteRenderer> ();
		/*if(other.name == "Taylor")
			Debug.Log ("hi!");*/
		switch (gameObject.layer) {
		case (16):
			if (other.gameObject.layer == 8) {
				other.gameObject.layer = 10;
				sprite.sortingLayerName = "C1";
			} else if (other.gameObject.layer == 10) {
				other.gameObject.layer = 8;
				sprite.sortingLayerName = "C0";
			}
			break;
		case (17):
			if (other.gameObject.layer == 10) {
				other.gameObject.layer = 12;
				sprite.sortingLayerName = "C2";
			} else if (other.gameObject.layer == 12) {
				other.gameObject.layer = 10;
				sprite.sortingLayerName = "C1";
			}
			break;
		case (18):
			if (other.gameObject.layer == 12) {
				other.gameObject.layer = 14;
				sprite.sortingLayerName = "C3";
			} else if (other.gameObject.layer == 14) {
				other.gameObject.layer = 12;
				sprite.sortingLayerName = "C2";
			}
			break;
		}
	}
}