using UnityEngine;
using System.Collections;

public class mobEnemy : MonoBehaviour {

    public string state;
    public GameObject otherEnemy;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        state = "active";
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.forward * -1);
        if (state == "idle")
        {
            Vector2 direction = transform.position - otherEnemy.transform.position;
            GetComponent<Rigidbody2D>().AddRelativeForce(-direction);
            StartCoroutine(UnIdle(.2f));
        }
    }


    public void idle()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            state = "idle";
            otherEnemy = coll.gameObject;
        }

    }

    IEnumerator UnIdle(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        state = "active";
    }
}
