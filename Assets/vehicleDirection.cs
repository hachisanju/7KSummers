using UnityEngine;
using System.Collections;

public class vehicleDirection : MonoBehaviour {

    GameObject mesh;
    public string meshName;
    GameObject LRCollider;
    GameObject UDCollider;

	// Use this for initialization
	void Start () {
        mesh = GameObject.Find(meshName);
        UDCollider = GameObject.Find("UpDownCollider");
        LRCollider = GameObject.Find("LeftRightCollider");
    }
	
	// Update is called once per frame
	void Update () {
        if ( (mesh.GetComponent<Transform>().rotation.eulerAngles.y < 135 && mesh.GetComponent<Transform>().rotation.eulerAngles.y > 45) || (mesh.GetComponent<Transform>().rotation.eulerAngles.y < 315 && mesh.GetComponent<Transform>().rotation.eulerAngles.y > 225))
        {
            UDCollider.SetActive(true);
            LRCollider.SetActive(false);
        }else
        {
            UDCollider.SetActive(false);
            LRCollider.SetActive(true);
        }
	    
	}
}
