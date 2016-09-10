using UnityEngine;
using System.Collections;

public class spriteInterchange : MonoBehaviour {

    private string bodySheetName = "Eli Body Sheet";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        var subSprites = Resources.LoadAll<Sprite>("Sprite_Sheets/Eli_test/" + bodySheetName);

        var renderers = GetComponentsInChildren<SpriteRenderer>();

        string spriteName = renderers[3].sprite.name;
        //print(subSprites);
        var newSprite = System.Array.Find(subSprites, item => item.name[item.name.Length -1] == spriteName[spriteName.Length -1]);
        if (newSprite)
            renderers[3].sprite = newSprite;
    }

    public void setBody(string name)
    {
        bodySheetName = name;
    }
}
