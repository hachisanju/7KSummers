using UnityEngine;
using System.Collections;

public class sorting3d : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MeshRenderer renderers = GetComponent<MeshRenderer>();

        renderers.sortingLayerName = "B0";
        renderers.sortingOrder = (int)((1.0f / (GetComponent<Transform>().position.y - (renderers.bounds.size.y / 4.0f))) * 100000000.0f);

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
}
