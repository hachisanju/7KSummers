using UnityEngine;
using System.Collections;

public class rotateTest : MonoBehaviour {

    MeshRenderer renderers;

    // Use this for initialization
    void Start () {
        renderers = GetComponent<MeshRenderer>();
        transform.Rotate(0, 90, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(0, 50 * Time.deltaTime, 0);
        renderers.sortingLayerName = "B0";
        renderers.sortingOrder = (int)((1.0f / (GetComponent<Transform>().position.y - (renderers.bounds.size.y / 4.0f))) * 100000000.0f);
        //print("Position = " + GetComponent<Transform>().position.y + " Bounds = " + renderers.bounds.size.y);
    }
}
