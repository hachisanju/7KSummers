using UnityEngine;
using System.Collections;

public class IndoorLighting : MonoBehaviour {

    GameObject Eli;

	// Use this for initialization
	void Start () {
        //GetComponent<Light>().enabled = false;
        Eli = GameObject.Find("Eli");
	}
	
	// Update is called once per frame
	/*void Update () {
	    if (Eli.GetComponent<playerPositioner>().getInside() == true)
        {
            GetComponent<Light>().enabled = true;
        }else
        {

        }
	}*/
}
