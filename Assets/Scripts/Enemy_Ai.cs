using UnityEngine;
using System.Collections;

public class Enemy_Ai : MonoBehaviour {

    Vector2 zero = new Vector2(0, 0);

    public Transform Target;
    private GameObject player;

    private float Range;
    public float speed;

    public bool ishit = false;
    public bool canhit = true;

    public float hittimer;
    public float stuntimer;

    public bool dead = false;

    public string state;

    private int HP;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        player = GameObject.Find("Eli");
        Debug.Log(player.GetComponent<Transform>().position.x);
        HP = 5;
        Debug.Log(HP);
        state = "Idle";
	}

	
	// Update is called once per frame
	void Update () {
     //   Debug.Log(state);
        if (!dead)
        {
            Alive();
        }
    }

    void FixedUpdate()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attack" && canhit == true)
        {
           // Debug.Log("hi!");

            Vector2 velocity = new Vector2((transform.position.x - player.GetComponent<Transform>().position.x) * 8, (transform.position.y - player.GetComponent<Transform>().position.y) * 8);
            //  Debug.Log(velocity);
            GetComponent<Rigidbody2D>().velocity = velocity;
            GetComponent<Rigidbody2D>().AddForce(player.GetComponent<TestPlayer>().forcey * 6f);
            GetComponent<Rigidbody2D>().AddForce(player.GetComponent<TestPlayer>().forcex * 6f);
            ishit = true;
            hittimer = .1f;
            stuntimer = .5f;
            canhit = false;
            GetComponent<AudioSource>().Play();
            HP--;
        }
    }

    void notHit(Vector2 zero)
    {
        canhit = true;
        if(ishit == true)
         GetComponent<Rigidbody2D>().velocity = zero;
        if(stuntimer <= 0)
            ishit = false;
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        // Debug.Log("Collide!");
        if (obj.gameObject.tag == "Attack")
            Physics2D.IgnoreCollision(obj.collider, GetComponent<Collider2D>());
        state = "hit";

    }

    void Alive()
    {
        
        if (HP <= 0)
        {
            Die();
            GetComponent<Rigidbody2D>().velocity = zero;
        }
        hittimer -= Time.deltaTime;
        stuntimer -= Time.deltaTime;


        //THIS METHOD
        /*
         * Doesn't seem like it's gonna work.... I probably need to use another vector instead of
         * xy... or make the x distance smaller than the y distance.... or.... SOMETHING....
         * in order to get values inside a slightly compressed circle's range...
        */

        float x = Mathf.Abs(transform.position.x - player.transform.position.x);
        float y = Mathf.Abs(transform.position.y - player.transform.position.y);
       // Debug.Log("X " + x + " + Y " + y);
        float xy = x + y;

     //   Debug.Log(xy);

        Vector2 velocity = new Vector2((transform.position.x - player.GetComponent<Transform>().position.x) * speed, (transform.position.y - player.GetComponent<Transform>().position.y) * speed);
        // Debug.Log(xy + "" + ishit);
        //Debug.Log("Vel = " + velocity + "XY = " + xy);
        if (xy < 4 && ishit == false)
        {
            notIdle(velocity, xy);
           /* Debug.Log("im in");
            GetComponent<Rigidbody2D>().velocity = -velocity;*/
        }
        else if (ishit == false)
            GetComponent<Rigidbody2D>().velocity = zero;

        if (hittimer <= 0)
            notHit(zero);
    }

    void notIdle(Vector2 vel, float xy)
    {
        if (/*player.GetComponent<TestPlayer>().attacking == false*/true)
        {
            if (xy < 1)
                Combat(vel, xy);
            else
                Chase(vel);
        }
        else
        {
            int decision = Random.Range(0, 1000);
            Debug.Log(decision); 
            if (decision <= 10)
                Dodge();
        }
    }

    void Combat(Vector2 velocity, float xy)
    {
        state = "Combat";
        if (xy > 1)
            GetComponent<Rigidbody2D>().velocity = zero;
        else
            GetComponent<Rigidbody2D>().velocity = velocity;


     /*   Vector3 zAxis = new Vector3(0, 0, 1);

     
        transform.RotateAround(player.transform.position, zAxis, speed);
        GetComponent<Rigidbody2D>().freezeRotation = true;*/
    }

    void Dodge()
    {
        state = "Dodge";
        Vector2 random = new Vector2(Random.Range(-10.0f, 10.0f)*(speed/2),Random.Range(-10.0f, 10.0f)*(speed/2));
        GetComponent<Rigidbody2D>().velocity = random;
        canhit = false;
        Wait();
    }

    void Chase(Vector2 vel)
    {
        Debug.Log("sup");
        state = "Chase";
        GetComponent<Rigidbody2D>().velocity = -vel;
    }

    void Wait()
    {
        stuntimer = .8f;
        hittimer = .1f;
        ishit = true;
    }

    void Die()
    {
        state = "Dead";
        GetComponent<Rigidbody2D>().velocity = zero;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        dead = true;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprite_Sheets/Dummy")[1];
    }
}
