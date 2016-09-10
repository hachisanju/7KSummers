using UnityEngine;
using System.Collections;

public class NPCTest : MonoBehaviour {

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
        script = new string []{ "You going to the underground rock\nconcert? Get it? Cuz we're in a cave..." };
        script2 = new string []{ "AAAAAAAAAA" };
        //Debug.Log(script[1]);
    }

    void OnTriggerEnter2D(Collider2D other){
		textbox = GameObject.Find ("TextBox");
		referencetext = GameObject.Find ("referencetext");
        referencetext.GetComponent<texttype>().done = true;
        done = true;
	}

    void Update()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
            timer -= Time.deltaTime;
    }



	void OnTriggerStay2D(Collider2D other){
        Debug.Log(other.tag);

        if (other.tag == "PlayerComponent")
        {
            
            if (Input.GetButton("A")|| Input.GetKey("z"))
            {

                if (done == true && timer <= 0)
                {
                    timer = 2f;
                    done = false;
                    //other.gameObject.GetComponent<TestPlayer>().Freeze();
                    textbox.GetComponent<CanvasRenderer>().SetAlpha(1);
                    //help
                    /*GameObject pportrait = GameObject.FindGameObjectWithTag("PlayerPortrait");
                    GameObject oportrait = GameObject.FindGameObjectWithTag("OtherPortrait");
                    pportrait.GetComponent<SpriteRenderer>().enabled = true;
                    oportrait.GetComponent<SpriteRenderer>().enabled = true;*/
                    referencetext.GetComponent<texttype>().Dialogue(script ,script.Length, true, "TV Dude");
                }
                else if (referencetext.GetComponent<texttype>().can_write == true && croute == false)
                {

                    StartCoroutine(Finish());
                }
            }
        }
        else if (other.tag == "Attack")
        {
            //textbox.GetComponent<CanvasRenderer>().SetAlpha(1);
            referencetext.GetComponent<texttype>().Dialogue(script2, 1, true, "TV Dude");
            GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Sprite_Sheets/Dummy")[1];
            foreach (Collider2D c in GetComponents<Collider2D>())
                c.enabled = false;
            dead = true;
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