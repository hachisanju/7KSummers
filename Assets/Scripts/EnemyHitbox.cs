using UnityEngine;
using System.Collections;

public class EnemyHitbox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
       // Debug.Log("Collide!");
        Physics2D.IgnoreCollision(hit.collider, GetComponent<Collider2D>());
        /*if(hit.gameObject.tag != "Player")
          Debug.Log(hit.gameObject.tag);
          */
    }

 /*   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attack")
            Debug.Log("hi!");
    }*/
}
