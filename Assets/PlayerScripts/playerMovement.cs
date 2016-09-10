using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float speed;
    public int speedmultiplier = 2;

    public bool idle;

    private playerPositioner positioner;

    private Animator animator;

    GameObject gun;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        positioner  = GetComponent<playerPositioner>();
        animator = GetComponent<Animator>();
        gun = GameObject.Find("GunArm");
        gun.SetActive(false);
        idle = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void FixedUpdate()
    {
        float input = Input.GetAxis ("Vertical");
		float input2 = Input.GetAxis ("Horizontal");

        float RInput = Input.GetAxis("Xbox360ControllerRightX");
        float RInput2 = Input.GetAxis("Xbox360ControllerRightY");
        if (RInput != 0 || RInput2 != 0)
            aim(RInput, RInput2);
        else
        {
            gun.SetActive(false);
            animator.SetBool("Aiming", false);
        }


            Movement(input, input2, false);
    }

    void Movement(float input, float input2, bool aiming)
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

            positioner.setFacing(0);

            idle = false;
        }

        else if (Input.GetKey("a") || (input2 <= -.1 && Mathf.Abs(input2) >= Mathf.Abs(input)))
        {
 
            animator.SetBool("Down", false);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);

            positioner.setFacing(1);

            idle = false;
        }

        else if (Input.GetKey("d") || (input2 >= .1 && Mathf.Abs(input2) >= Mathf.Abs(input)))
        {

            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
            animator.SetBool("Up", false);

            positioner.setFacing(3);

            idle = false;
        }

        else if (Input.GetKey("w") || (input >= .1 && Mathf.Abs(input2) < Mathf.Abs(input)))
        {
            
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", true);

            positioner.setFacing(2);

            idle = false;
        }

        else
        {
            animator.SetBool("Walk", false);
            idle = true;
            return;
        }

        if (!aiming)
        {
            gun.SetActive(false);
            animator.SetBool("Aiming", false);
            animator.SetBool("Walk", true);
            applyForce(input, input2);
            idle = false;
        }
    }

    void applyForce(float input, float input2)
    {
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * (speed / 4) * 3 * input * speedmultiplier);
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * speed * input2 * speedmultiplier);
    }

    void aim(float input, float input2)
    {
        if (idle == true)
        {
            gun.SetActive(true);
            animator.SetBool("Aiming", true);
        }


            Movement(-input2, input, true);
        if (input != 0.0f || input2 != 0.0f)
        {

            float aim_angle = Mathf.Atan2(input, input2) * Mathf.Rad2Deg;

            // ANGLE GUN
            gun.transform.rotation = Quaternion.AngleAxis(aim_angle, Vector3.forward);
        }
    }

}
