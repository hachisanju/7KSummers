using UnityEngine;
using System.Collections;

public class childOrderSetter : MonoBehaviour {

    private SpriteRenderer Head;
    private SpriteRenderer Back;
    private SpriteRenderer Body;
    private SpriteRenderer Legs;
    private SpriteRenderer GunArm;
    private int order;
    private playerPositioner positioner;
    private SpriteRenderer thisRenderer;

    // Use this for initialization
    void Start () {
        positioner = GetComponent<playerPositioner>();
        Head = transform.FindChild("Head").GetComponent<SpriteRenderer>();
        Back = transform.FindChild("Back").GetComponent<SpriteRenderer>();
        Body = transform.FindChild("Body").GetComponent<SpriteRenderer>();
        Legs = transform.FindChild("Legs").GetComponent<SpriteRenderer>();
        GunArm = transform.FindChild("GunArm").GetComponent<SpriteRenderer>();
        thisRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        order = GetComponent<SpriteRenderer>().sortingOrder;
        Back.sortingLayerName = thisRenderer.sortingLayerName;
        Head.sortingLayerName = thisRenderer.sortingLayerName;
        Body.sortingLayerName = thisRenderer.sortingLayerName;
        Legs.sortingLayerName = thisRenderer.sortingLayerName;
        GunArm.sortingLayerName = thisRenderer.sortingLayerName;

        Back.transform.position = GetComponent<Transform>().position;
        Head.transform.position = GetComponent<Transform>().position;
        Legs.transform.position = GetComponent<Transform>().position;
        Body.transform.position = GetComponent<Transform>().position;
        GunArm.transform.position = GetComponent<Transform>().position + new Vector3(.1f, -.1f) ;

        if (positioner.getFacing() == 2)
            north();
        else
            nonNorth(); 
    }

    void nonNorth()
    {
        Back.sortingOrder = order;
        Legs.sortingOrder = order + 1;
        Body.sortingOrder = order + 2;
        Head.sortingOrder = order + 3;
        GunArm.sortingOrder = order + 4;
    }

    void north()
    {
        GunArm.sortingOrder = order - 1;
        Legs.sortingOrder = order + 0;
        Head.sortingOrder = order + 1;
        Body.sortingOrder = order + 2;
        Back.sortingOrder = order + 3;
    }
}
