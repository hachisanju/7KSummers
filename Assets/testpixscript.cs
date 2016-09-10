using UnityEngine;
using System.Collections;

public class testpixscript: MonoBehaviour
{

    void Awake()
    {
        this.GetComponent<Camera>().orthographicSize = Screen.height / 2;
    }
}
