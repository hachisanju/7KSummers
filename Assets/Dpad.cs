using UnityEngine;
using System.Collections;

public class Dpad : MonoBehaviour
{
    public bool up;
    public bool down;
    public bool left;
    public bool right;


    float lastX;
    float lastY;

    public bool xpressed = false;
    public bool ypressed = false;

    public Dpad()
    {
        up = down = left = right = false;
        /*lastX = Input.GetAxis("Xbox360ControllerDPadX");
        lastY = Input.GetAxis("Xbox360ControllerDPadY");*/
    }

    void Update()
    {
        if (Input.GetAxis("Xbox360ControllerDPadX") == 1 && lastX != 1) { right = true; } else { right = false; }
        if (Input.GetAxis("Xbox360ControllerDPadX") == -1 && lastX != -1) { left = true; } else { left = false; }
        if (Input.GetAxis("Xbox360ControllerDPadY") == 1 && lastY != 1) { up = true; } else { up = false; }
        if (Input.GetAxis("Xbox360ControllerDPadY") == -1 && lastY != -1) { down = true; } else { down = false; }

    }

    void LateUpdate()
    {
        if (right || left)
            xpressed = true;
        else
            xpressed = false;

        if (up || down)
            ypressed = true;
        else
            ypressed = false;
    }
}