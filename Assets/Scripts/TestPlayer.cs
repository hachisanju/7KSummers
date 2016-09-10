using UnityEngine;
using System.Collections;

public class TestPlayer: MonoBehaviour {

	public float speed;
	public int speedmultiplier = 1;

	public int facing;


    public float timer;
    public float combo;
    public float dashtimer;
    public bool attacking = false;
    public int attack = 0;
    public Vector2 forcex;
    public Vector2 forcey;

    float dir1;
    float dir2;


    public Animator animator;

	public bool Interact = false;

	private SpriteRenderer sprite;

	Sprite[] taylor;

	void Start(){
        GetComponent<Rigidbody2D>().freezeRotation = true;
        facing = 0;
        animator = GetComponent<Animator>();

    }

	void Update()
	{
        float input = Input.GetAxis("Vertical");
        float input2 = Input.GetAxis("Horizontal");
     //   Debug.Log("Input1" + input + "Input2" + input2);

        float angle = Mathf.Atan2(input, input2) * Mathf.Rad2Deg;
        //INTERACT / timer stuff
        timer -= Time.deltaTime;
        dashtimer -= Time.deltaTime;
        combo -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) || Input.GetButton("A"))
        {
            Interact = true;

        }
        else
            Interact = false;


      /*  if (Time.timeScale != 1)
        {
            Freeze();
        }*/


        //////////// /*ANIMATION STUFF*///////////////

        //Dashing
        if (dashtimer <= 0 && (Input.GetKeyDown("c") || Input.GetButtonDown("A")))
        {
            dashtimer = .05f;
            animator.SetBool("Dash", true);
            Dash(input, input2);
        }


	    //Attacking

        if ((Input.GetKeyDown("x") || Input.GetButtonDown("X")) && Time.timeScale==1 && timer<=0)
        {
            attack++;
            
            Attack(input, input2);
            attacking = true;
        }
        if (attacking == true)
        {
            Attack(input, input2);
        }

        //Directional

        if (attacking == false)
            Movement(input, input2);
        if (dashtimer <= 0)
         animator.SetBool("Dash", false);


    }
	void FixedUpdate()
	{		
		float input = Input.GetAxis ("Vertical");
		float input2 = Input.GetAxis ("Horizontal");
        
        if (attacking == false)
        {
            GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * (speed / 4) * 3 * input * speedmultiplier);
            GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * speed * input2 * speedmultiplier);
        }
    }

    void Movement(float input, float input2)
    {

        

        //Running
        if (Input.GetKey(KeyCode.LeftShift) || (Mathf.Abs(input) > .5 || Mathf.Abs(input2) > .5))
        {
            speedmultiplier = 2;
            animator.SetBool("Run", true);
        }
        else
        {
            speedmultiplier = 1;
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("s") || (input <= -.1 && Mathf.Abs(input2) < Mathf.Abs(input)))
        {
            animator.SetBool("Down", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Walk", true);
            //  transform.Translate(0, -speed * Time.deltaTime, 0);

            dir1 = -1;
            dir2 = 0;
        }

        else if (Input.GetKey("a") || (input2 <= -.1 && Mathf.Abs(input2) >= Mathf.Abs(input)))
        {
            animator.SetBool("Down", false);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Walk", true);
            //  transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        else if (Input.GetKey("d") || (input2 >= .1 && Mathf.Abs(input2) >= Mathf.Abs(input)))
        {
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
            animator.SetBool("Up", false);
            animator.SetBool("Walk", true);
            //transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        else if (Input.GetKey("w") || (input >= .1 && Mathf.Abs(input2) < Mathf.Abs(input)))
        {
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", true);
            animator.SetBool("Walk", true);
            //transform.Translate(0, speed * Time.deltaTime, 0);
        }

        else
            animator.SetBool("Walk", false);
    }

    void Attack(float input, float input2)
    {
        if (attack == 1)
        {
            animator.SetBool("Attack", true);
            animator.SetInteger("AttackVal", 1);

            timer = .2f;
            combo = .4f;

            forcey = gameObject.transform.up * (speed / 4) * 3 * input * 15;
            forcex = gameObject.transform.right * speed * input2 * 15;

            GetComponent<Rigidbody2D>().AddForce(forcey);
            GetComponent<Rigidbody2D>().AddForce(forcex);
            attack++;
        }
        if (attack == 3)
        {
            animator.SetInteger("AttackVal", 2);

            timer = .2f;
            combo = .4f;

            forcey = gameObject.transform.up * (speed / 4) * 3 * input * 15;
            forcex = gameObject.transform.right * speed * input2 * 15;

            GetComponent<Rigidbody2D>().AddForce(forcey);
            GetComponent<Rigidbody2D>().AddForce(forcex);
            attack++;
        }

        if (attack == 5)
        {
            animator.SetInteger("AttackVal", 3);

            timer = .2f;
            combo = .4f;

            /*
            forcey = gameObject.transform.up * (speed / 4) * 3 * input * 80;
            forcex = gameObject.transform.right * speed * input2 * 80;
            */
            forcey = gameObject.transform.up * (speed / 4) * 3 * dir1 * 80;
            forcex = gameObject.transform.right * speed * dir2 * 80;

            GetComponent<Rigidbody2D>().AddForce(forcey);
            GetComponent<Rigidbody2D>().AddForce(forcex);
            attack = 0;
        }

        if (combo <= 0)
        {
          //  Debug.Log("Done");
            attacking = false;
            animator.SetBool("Attack", false);
            animator.SetInteger("AttackVal", 0);
            attack = 0;
        }
     }

    void Dash(float input, float input2)
    {
        
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * (speed / 4) * 3 * input * 50);
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * speed * input2 * 50);
        
    }

    public void Freeze()
    {
        //animator.Play("DIdle");

        animator.SetBool("Run", false);
        animator.SetBool("Walk", false);
        animator.SetBool("Dash", false);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}