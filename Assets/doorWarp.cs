using UnityEngine;
using System.Collections;

public class doorWarp : MonoBehaviour {


    public string destinationName;
    GameObject destination;
    GameObject player;
    GameObject OutsideLight;
    GameObject InsideLight;

    void Start()
    {
        OutsideLight = GameObject.Find("OutsideLight");
        InsideLight = GameObject.Find("InsideLight");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerComponent"||other.tag == "Player")
        {
            destination = GameObject.Find(destinationName);
            player = GameObject.Find("Eli");
            player.GetComponent<Transform>().position = destination.GetComponent<Transform>().position;
            if (OutsideLight.GetComponent<Light>().enabled == true)
            {
                OutsideLight.GetComponent<Light>().enabled = false;
                InsideLight.GetComponent<Light>().enabled = true;
            }
            else
            {
                OutsideLight.GetComponent<Light>().enabled = true;
                InsideLight.GetComponent<Light>().enabled = false;
            }
        }
    }
}
