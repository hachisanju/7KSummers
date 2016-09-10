using UnityEngine;
using System.Collections;

public class playerPositioner : MonoBehaviour
{

    public float speed;
    public int speedmultiplier = 1;

    private int facing;
    private bool outside = true;
    private bool inside = false;


    public Animator animator;

    public bool Interact = false;

    private SpriteRenderer sprite;

    Sprite[] taylor;

    void Start()
    {
        facing = 0;
        animator = GetComponent<Animator>();
        animator.SetBool("Down", true);
    }

    public void setFacing(int i)
    {
        facing = i;
        switch (facing)
        {
            /*case 0:
                animator.SetBool("Up", false);
                animator.SetBool("Down", true);
                break;
            case 2:
                animator.SetBool("Up", true);
                animator.SetBool("Down", false);
                break;*/

        }
    }
    public int getFacing()
    {
        return facing;
    }

    public void setOutside()
    {
        outside = true;
        inside = false;
    }
    public void setInside()
    {
        outside = false;
        inside = true;
    }
    public bool getOutside()
    {
        return outside;
    }
    public bool getInside()
    {
        return inside;
    }

}