using UnityEngine;
using System.Collections;

public class mobFollow : MonoBehaviour {

    public Transform Target;
    private GameObject player;

    public float attackRange;
    public float followRange;
        

    private float Range;
    public float speed;
    Vector2 velocity;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Eli");
        
        

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        var velocities = GetComponentsInChildren<Transform>();
        var mobEnemies = GetComponentsInChildren<mobEnemy>();
        for (int i = 1; i < velocities.Length; i++)
        {
            float x = Mathf.Abs(velocities[i].transform.position.x - player.transform.position.x);
            float y = Mathf.Abs(velocities[i].transform.position.y - player.transform.position.y);
            float xy = x + y;
            if (attackRange < xy && xy < followRange && velocities[i].gameObject.tag == "Enemy")
            {
                velocity = new Vector2((velocities[i].transform.position.x - player.GetComponent<Transform>().position.x) * speed, (velocities[i].transform.position.y - player.GetComponent<Transform>().position.y) * speed);
                //velocities[i].GetComponent<mobEnemy>().chase(velocity);
                velocities[i].GetComponent<Rigidbody2D>().freezeRotation = true;
                velocities[i].GetComponent<Rigidbody2D>().AddRelativeForce(-velocity);
            }
            else if (velocities[i].gameObject.tag == "Enemy") 
                velocities[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
         

    }
}
