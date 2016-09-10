using UnityEngine;
using System.Collections;

public class enterCar : MonoBehaviour {

    GameObject car;


    void OnStart()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        print("intrigger");

        if ((other.tag == "Player" || other.tag == "PlayerComponent") && (Input.GetButton("A") || Input.GetKey("z")))
            GetComponentInParent<carIdle>().EnterCar();
    }
}
