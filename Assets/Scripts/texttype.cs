using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class texttype : MonoBehaviour {

	public float letterPause = 0.1f;
	public int pause = 25;
	public AudioSource typesound;
	public AudioClip sfx;
	public bool can_write = false;
	public int scene = 0;
	public string dialogue = "";
	public bool done = false;
	public float timer = 5;
    public string[] scrip;
    public int leng;
    public int val = 0;
    public bool active = false;
    public string speaker;

    public bool portraits = false;

    GameObject pportrait;
    GameObject oportrait;

    string message;
	Text textComp;
	void Start(){
		typesound = GetComponent<AudioSource> ();
		sfx = Resources.Load<AudioClip> ("SFX/typesound.wav");
        pause = 50;
        pportrait = GameObject.FindGameObjectWithTag("PlayerPortrait");
        oportrait = GameObject.FindGameObjectWithTag("OtherPortrait");
        speaker = "";
    }

    void Update()
    {
        if (active == true)
        {
            GameObject.Find("speakertext").GetComponent<Text>().text = speaker;
            
            GameObject.Find("TextBox").GetComponent<CanvasRenderer>().SetAlpha(0.8f);
            if (portraits == true)
            {
                //pportrait.GetComponent<SpriteRenderer>().enabled = true;
                pportrait.GetComponent<Image>().enabled = true;
                //oportrait.GetComponent<SpriteRenderer>().enabled = true;
                oportrait.GetComponent<Image>().enabled = true;
            }
        }
        if (Input.GetButtonDown("X")||Input.GetKeyDown("x"))
            pause = 12;
        else if (Input.GetButtonUp("X")||Input.GetKeyUp("x")) 
            pause = 50;
        //Debug.Log(can_write);
        if (can_write == true && (Input.GetKey("z") || Input.GetButton("A")))
        {
            if (done == true && active == true)
            {
                //Time.timeScale = 1;
                can_write = false;
                val++;
                Dialogue(scrip, leng - 1, portraits, speaker);
                //transform.parent.GetComponent<CanvasRenderer>().SetAlpha(0);
                //write("");
            }


            else if (done == false && active == true)
            {
                pause = 50;
                active = false;
                val = 0;
                Time.timeScale = 1;
                write("");
                transform.parent.GetComponent<CanvasRenderer>().SetAlpha(0);
                pportrait.GetComponent<Image>().enabled = false;
                oportrait.GetComponent<Image>().enabled = false;
                GameObject.Find("speakertext").GetComponent<Text>().text = "";
                portraits = false;
                speaker = "";
                
            }
            
        }
    }

	void FixedUpdate(){
		if (can_write == true && done == false)
			write (dialogue);
    }

    public void Dialogue(string[] script, int length, bool ports, string spk)
    {
        speaker = spk;
        if (ports == true)
            portraits = true;
        
        active = true;
        if (length != 1)
            done = true;
        else
            done = false;
        scrip = script;
        leng = length;
        Time.timeScale = 0;
        write(script[val]);
    }

	// Use this for initialization
	public void write (string literal) {
		can_write = false;
		textComp = GetComponent<Text>();
		message = literal;
		textComp.text = "";
		StartCoroutine(TypeText ());

	}

	IEnumerator TypeText () {
		foreach (char letter in message.ToCharArray()) {
			System.Threading.Thread.Sleep (pause);
			textComp.text += letter;
			//if (typeSound1 && typeSound2)
			//	SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
			typesound.Play();
			yield return 0;

			//yield return new WaitForSeconds (letterPause);
		}
        can_write = true;
		if (scene == 10)
			done = true;
	}
}