using UnityEngine;
using System.Collections;

public class blockLoader : MonoBehaviour {

    GameObject localBlock;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D()
    {
        print("Hi!");
        GameObject localBlock = Instantiate(Resources.Load("Maps/Zone 1/BlockA", typeof(GameObject))) as GameObject;
    }
    void OnTriggerExit2D()
    {
        print("Bye!");
        Destroy(localBlock);
    }
}
