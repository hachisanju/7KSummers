using UnityEngine;
using System.Collections;

public class npcMovement : MonoBehaviour {

    public float speed;
    public int speedmultiplier = 2;

    private playerPositioner positioner;

    private Animator animator;

    float input;
    float input2;

    public float stopRange;

    private GameObject player;

    bool moving = false;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Eli");
        animator = GetComponent<Animator>();
        positioner = GetComponent<playerPositioner>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        input2 = -(GetComponent<Transform>().position.x - player.transform.position.x);
        input = -(GetComponent<Transform>().position.y - player.transform.position.y);

//        x = Mathf.Abs(GetComponent<Transform>().position.x - player.transform.position.x);
//        y = Mathf.Abs(GetComponent<Transform>().position.y - player.transform.position.y);
        
        float xy = Mathf.Abs(input) + Mathf.Abs(input2);
        if (stopRange < xy)
        {

            moving = true;

            Vector2 velocity = new Vector2((GetComponent<Transform>().position.x - player.GetComponent<Transform>().position.x) * speed, (GetComponent<Transform>().position.y - player.GetComponent<Transform>().position.y) * speed);
            /*if ((Mathf.Abs(input) > .5 || Mathf.Abs(input2) > .5))
            {
                speedmultiplier = 2;
                animator.SetBool("Run", true);
            }
            else
            {
                speedmultiplier = 1;
                animator.SetBool("Run", false);
            }*/
            animator.SetBool("Walk", true);
            animator.SetBool("Run", true);
            

            if ((input <= -.1 && Mathf.Abs(input2) < Mathf.Abs(input)))
            {
                animator.SetBool("Down", true);
                animator.SetBool("Left", false);
                animator.SetBool("Right", false);
                animator.SetBool("Up", false);
                animator.SetBool("Walk", true);
                positioner.setFacing(0);

            }

            else if ((input2 <= -.1 && Mathf.Abs(input2) >= Mathf.Abs(input)))
            {
                animator.SetBool("Down", false);
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                animator.SetBool("Up", false);
                animator.SetBool("Walk", true);
                positioner.setFacing(1);
            }

            else if ((input2 >= .1 && Mathf.Abs(input2) >= Mathf.Abs(input)))
            {
                animator.SetBool("Down", false);
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);
                animator.SetBool("Up", false);
                animator.SetBool("Walk", true);
                positioner.setFacing(3);
            }

            else if ((input >= .1 && Mathf.Abs(input2) < Mathf.Abs(input)))
            {
                animator.SetBool("Down", false);
                animator.SetBool("Left", false);
                animator.SetBool("Right", false);
                animator.SetBool("Up", true);
                animator.SetBool("Walk", true);
                positioner.setFacing(2);
            }
            GetComponent<Rigidbody2D>().AddRelativeForce(-velocity);

        }
        else
        {
            moving = false;
            StartCoroutine(WalkTimer());
        }
        
    }

    public void walk()
    {
        animator.SetBool("Run", false);
        StartCoroutine(StopTimer());
    }

    public void stop()
    {
        animator.SetBool("Walk", false);
    }

    IEnumerator WalkTimer()
    {

        yield return new WaitForSeconds(.25f);
        if (moving == false)
            walk();
    }


    IEnumerator StopTimer()
    {

        yield return new WaitForSeconds(.25f);
        if (moving == false)
            stop();
    }
}
