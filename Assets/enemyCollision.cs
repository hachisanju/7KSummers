using UnityEngine;
using System.Collections;

public class enemyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Enemy")
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), coll.gameObject.GetComponent<BoxCollider2D>());
    }
}
