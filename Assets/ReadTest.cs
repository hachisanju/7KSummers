using UnityEngine;
using System.Collections;

public class ReadTest : MonoBehaviour
{

    public GameObject textbox;
    public GameObject referencetext;
    bool done = true;
    float timer;
    bool croute = false;
    public bool dead = false;

    public string[] script;
    public string[] script2;

    void Start()
    {
        script = new string[] { "Someone appears to have put up\na flyer.", "It seems like they're looking\nfor a drummer." };
        script2 = new string[] { "You consider saving your moves\nfor the audition." };
        //Debug.Log(script[1]);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        textbox = GameObject.Find("TextBox");
        referencetext = GameObject.Find("referencetext");
        referencetext.GetComponent<texttype>().done = true;
        done = true;
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }


    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            if (Input.GetButton("A") || Input.GetKey("z"))
            {

                if (done == true && timer <= 0)
                {
                    timer = 2f;
                    done = false;
                    Debug.Log("eh");
                    other.gameObject.GetComponent<TestPlayer>().Freeze();
                    textbox.GetComponent<CanvasRenderer>().SetAlpha(1);
                    //help
                    /*GameObject pportrait = GameObject.FindGameObjectWithTag("PlayerPortrait");
                    GameObject oportrait = GameObject.FindGameObjectWithTag("OtherPortrait");
                    pportrait.GetComponent<SpriteRenderer>().enabled = true;
                    oportrait.GetComponent<SpriteRenderer>().enabled = true;*/
                    referencetext.GetComponent<texttype>().Dialogue(script, script.Length, false, "");
                }
                else if (referencetext.GetComponent<texttype>().can_write == true && croute == false)
                {
                    Debug.Log("heh");

                    StartCoroutine(Finish());
                }
            }
        }
        else if (other.tag == "Attack")
        {
            if (done == true && timer <= 0)
            {
                timer = 2f;
                done = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<TestPlayer>().Freeze();
                referencetext.GetComponent<texttype>().Dialogue(script2, 1, false, "");
            }
            else if (referencetext.GetComponent<texttype>().can_write == true && croute == false)
            {
                Debug.Log("heh");

                StartCoroutine(Finish());
            }
        }
    }
    IEnumerator Finish()
    {
        croute = true;
        yield return new WaitForSeconds(1);
        done = true;
        croute = false;
    }
}