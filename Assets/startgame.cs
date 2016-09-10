using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour {

	public bool start = false;
	public float timer = 1f;

    public Texture2D fadeoutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    public void Start()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Test Room", LoadSceneMode.Additive);
        async.allowSceneActivation = false;
    }

	public void Update () {
		if (Input.GetKeyDown (KeyCode.Space)||Input.GetButtonDown("a"))
			SceneTransition ();

		if (start == true)
			timer -= Time.deltaTime;

		if (timer <= 0) {
            /*  Scene activeScene = SceneManager.GetActiveScene();
              SceneManager.UnloadScene(activeScene.buildIndex);
              SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestRoom"));*/
            
			SceneManager.LoadScene ("Test Room");
		}
	}
	public void SceneTransition()
	{
        GameObject cam = FindObjectOfType<Camera>().gameObject;
        //cam.GetComponent<AudioSource>().volume -= 1;
        StartCoroutine(FadeOut(cam.GetComponent<AudioSource>(), 3.0f));
        BeginFade(1);
		GetComponent<AudioSource> ().Play ();
		start = true;
		//System.Threading.Thread.Sleep (1000);
		//SceneManager.LoadScene ("Test Scene");

	}

    void OnGUI ()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeoutTexture);

    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

}
