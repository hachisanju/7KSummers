using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	public int speedmultiplier = 1;

	public int facing;

	public int increment;

    public float timer;// = 0.2f;

	public int []spin = new int[] {0, 1, 2, 3, 4 ,5 ,6 ,7};

	public int []south = new int[] {1, 0, 2, 0};
	public int []southwest = new int[] {4, 3, 5, 3};
	public int []west = new int[] {7, 6, 8, 6};
	public int []northwest = new int[] {10, 9, 11, 9};
	public int []north = new int[] {13, 12, 14, 12};
	public int []northeast = new int[] {16, 15, 17, 15};
	public int []east = new int[] {19, 18, 20, 18};
	public int []southeast = new int[] {22, 21, 23, 21};
	public int []direction = new int[3];

    //public Animator animator;

	public bool Interact = false;

	private SpriteRenderer sprite;

	Sprite[] taylor;

	void Start(){
		//taylor = Resources.LoadAll<Sprite>("Sprite_Sheets/n_taylor");
		//sprite = GetComponent<SpriteRenderer> ();
		facing = 0;
		int increment = 1;
        //animator = GetComponent<Animator>();

    }

	void Turn(int num)
	{
//		taylor = Resources.LoadAll<Sprite>("Sprite_Sheets/taylor");
		//GetComponent<SpriteRenderer> ().sprite = taylor[num];
	}

	void dir()
	{
	}
	/*void dir(float rot, float rot2)
	{
		//Debug.Log ("Z" + rot + "W" + rot2);

		if (rot2 < -.7 && rot < .7) {
			facing = 6;
			Turn (6);
		} else if (rot > .93) {
			facing = 0;
			Turn (0);
		} else if (rot > .7 && rot2 < 0) {
			facing = 7;
			Turn (7);
		} else if (rot > .7 && rot2 > 0) {
			facing = 1;
			Turn (1);
		} else if (rot > .4) {
			facing = 2;
			Turn (2);
		} else if (rot > .1) {
			facing = 3;
			Turn (3);
		} else if (rot > -.1) {
			facing = 4;
			Turn (4);
		} else if (rot > -.4) {
			facing = 5;
			Turn (5);
		} else if (rot > -.7) {
			facing = 6;
			Turn (6);
		} else {
			facing = 7;
			Turn (7);
		}
	}*/
	void Update()
	{

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedmultiplier = 2;
            //animator.SetBool("Run", true);
        }
        else
        {
            speedmultiplier = 1;
            //animator.SetBool("Run", false);
        }
        //  Debug.Log(Interact);
        timer -= Time.deltaTime;
		if (Input.GetKey (KeyCode.Z)) {
			Interact = true;
		}
		else
			Interact = false;
/*
        if (Input.GetKeyDown("x"))
        {
            animator.SetBool("Attack", true);
        }
        if (Input.GetKeyUp("x"))
            animator.SetBool("Attack", false);

        if (Input.GetKey("s"))
        {
            animator.SetBool("Down", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Walk", true);
        }

        else if (Input.GetKey("a"))
        {
            animator.SetBool("Down", false);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Walk", true);
        }

        else if (Input.GetKey("d"))
        {
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
            animator.SetBool("Up", false);
            animator.SetBool("Walk", true);
        }

        else if (Input.GetKey("w"))
        {
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", true);
            animator.SetBool("Walk", true);
        }

        else
            animator.SetBool("Walk", false);*/

    }
	void FixedUpdate()
	{
        

        var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		Vector3 correct = transform.position - new Vector3(0,15,0);
		Quaternion rot = Quaternion.LookRotation (correct - mousePosition, 
			                 Vector3.forward);
		//Debug.Log ("Z" + rot.z + "W" + rot.w + "X" + rot.x + "Y" + rot.y );
		//Debug.Log (rot.y);
		//dir (rot.z, rot.w);
		//Debug.Log (rot.z);
		//No rotation

		GetComponent<Rigidbody2D>().freezeRotation = true;
		float input = Input.GetAxis ("Vertical");
		float input2 = Input.GetAxis ("Horizontal");

        

		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * (speed/4)*3 * input*speedmultiplier);
		GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.right * speed * input2*speedmultiplier);
		if(Input.GetKeyDown("/"))
		//	zSort();
		//Invoke ("animate", timer);
		if (timer <= 0) {
			//animate2 ();
			timer +=0.2f;
		}
        /*if (Input.GetKey("s"))
            animator.SetBool("Down", true);
        else
            animator.SetBool("Down", false);*/

        

    }

	/*void NextSprite(int[] animation, int animation_size)
	{
		//Debug.Log (animation [increment]);
		GetComponent<SpriteRenderer> ().sprite = taylor [animation [increment]];
		if (increment < animation_size)
			increment++;
		else
			increment = 0;
	}*/

	/*void animate(){
		
		if (Input.GetKey("s") && Input.GetKey("a"))
			{
				NextSprite (southwest, 3);
			}
		else if (Input.GetKey("s") && Input.GetKey("d"))
		{
			NextSprite (southeast, 3);
		}
		else if (Input.GetKey("w") && Input.GetKey("a"))
		{
			NextSprite (northwest, 3);
		}
		else if (Input.GetKey("w") && Input.GetKey("d"))
		{
			NextSprite (northeast, 3);
		}
		else if (Input.GetKey("s"))
		{
			NextSprite (south, 3);
		}
		else if (Input.GetKey("a"))
		{
			NextSprite (west, 3);
		}
		else if (Input.GetKey("w"))
		{
			NextSprite (north, 3);
		}
		else if (Input.GetKey("d"))
		{
			NextSprite (east, 3);
		}
		else {
			Turn (0);
			}
		/*GetComponent<SpriteRenderer> ().sprite = taylor[facing + increment];
		Debug.Log (increment);
		if (increment <= 3)
			increment += 1;
		else
			increment = 1;
	}*/

/*	void animate2(){

    //    float input = Input.GetAxis("Vertical");
    //   	float input2 = Input.GetAxis ("Horizontal");
        

        if (Input.GetKey("s") && Input.GetKey("a"))
		{
			direction = southwest;
			NextSprite (direction, 3);
		}
		else if (Input.GetKey("s") && Input.GetKey("d"))
		{
			direction = southeast;
			NextSprite (direction, 3);
		}
		else if (Input.GetKey("w") && Input.GetKey("a"))
		{
			direction = northwest;
			NextSprite (direction, 3);
		}
		else if (Input.GetKey("w") && Input.GetKey("d"))
		{
			direction = northeast;
			NextSprite (direction, 3);
		}
		else if (Input.GetKey("s"))
		{
			direction = south;
			NextSprite (direction, 3);
		}
		else if (Input.GetKey("a"))
		{
			direction = west;
			NextSprite (direction, 3);
		}
		else if (Input.GetKey("w"))
		{
			direction = north;
			NextSprite (direction, 3);
		}
		else if (Input.GetKey("d"))
		{
			direction = east;
			NextSprite (direction, 3);
		}
		else {
			NextSprite (direction, 0);
		}

    }*/


/*	void zSort(){

		string sw = sprite.sortingLayerName;
		if (sprite) {
			switch (sw) {
			case("C0"):
				sprite.sortingLayerName = "C1";
				gameObject.layer = 10;
				break;
			case("C1"):
				sprite.sortingLayerName = "C2";
				gameObject.layer = 12;
				break;
			case("C2"):
				sprite.sortingLayerName = "C3";
				gameObject.layer = 14;
				break;
			case("C3"):
				sprite.sortingLayerName = "C0";
				gameObject.layer = 8;
				break;
			}
			sprite.sortingOrder = 2;
		}
	}*/
		

}