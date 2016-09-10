using UnityEngine;
using System.Collections;

public class carIdle : MonoBehaviour
{

    MeshRenderer renderers;
    GameObject model;
    GameObject player;
    bool inCar;
    GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        inCar = false;
        player = GameObject.Find("Eli");
        model = GameObject.Find("carBody").gameObject;
        renderers = model.GetComponent<MeshRenderer>();
        model.transform.Rotate(0, 90, 0);
        mainCamera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inCar)
            Driving();
        //transform.Rotate(0, 50 * Time.deltaTime, 0);
        renderers.sortingLayerName = "B0";
        renderers.sortingOrder = (int)((1.0f / (GetComponent<Transform>().position.y - (renderers.bounds.size.y / 4.0f))) * 100000000.0f);
    }

    public void EnterCar()
    {
        print("Hey");
        player.SetActive(false);
        inCar = true;
        player.GetComponent<SpriteRenderer>().sortingLayerName = "C0";
        mainCamera.GetComponent<CameraTarget>().target = this.transform;
    }

    void Driving()
    {
        float RInput = Input.GetAxis("Vertical");
        float RInput2 = Input.GetAxis("Horizontal");
        steer(RInput, RInput2);
        if (Input.GetKey("z") || Input.GetButton("X")){
            exitCar();
        }
        
    }

    void exitCar()
    {
        inCar = false;
        player.SetActive(true);
        player.transform.position = GetComponent<Transform>().position;
        player.GetComponent<SpriteRenderer>().sortingLayerName = model.GetComponent<Renderer>().sortingLayerName;
        mainCamera.GetComponent<CameraTarget>().target = player.transform;
        this.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void steer(float input, float input2)
    {

        if (input != 0.0f || input2 != 0.0f)
        {
            
            float aim_angle = -Mathf.Atan2(input, input2) * Mathf.Rad2Deg;
            print(aim_angle + "||" + model.transform.rotation.eulerAngles.z);
            /*if ((aim_angle >= 0 && model.transform.rotation.eulerAngles.y%360 < aim_angle) || (aim_angle <= 0 && model.transform.rotation.eulerAngles.y%360 < aim_angle + 180))
             {
                 model.transform.Rotate(0, 120 * Time.deltaTime, 0);
                 print(aim_angle + " > " + model.transform.rotation.eulerAngles.y);
             }
            else if ((aim_angle <= 0 && model.transform.rotation.eulerAngles.y%360 < aim_angle) || (aim_angle >= 0 && model.transform.rotation.eulerAngles.y%360 < aim_angle + 180))
            {
                model.transform.Rotate(0, -120 * Time.deltaTime, 0);
                print(aim_angle + " > " + model.transform.rotation.eulerAngles.y);
            }*/

            //GetComponent<Rigidbody2D>().AddForce(model.transform.right * 40f);
            GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * (25f / 8) * 5 * input * 5f);
            GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * 25f * input2 * 5f);
            //GetComponent<Rigidbody2D>().AddForce(model.transform.up * 40f);
            //model.transform.Rotate(new Vector3(0, 50, 0), aim_angle);
            // model.transform.eulerAngles = new Vector3(model.transform.eulerAngles.x, aim_angle, model.transform.eulerAngles.z);
            //Vector3 carUp = model.transform.rotation * Vector3.up;
            Quaternion newRotation = Quaternion.AngleAxis(aim_angle, Vector3.up);
            //model.transform.localRotation = Quaternion.identity * newRotation;
            model.transform.localRotation = Quaternion.Lerp(model.transform.localRotation, newRotation, Time.time * 2f);

        }
    }
}
