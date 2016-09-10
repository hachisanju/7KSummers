using UnityEngine;
using System;

public class ReSkinGemma : MonoBehaviour
{

    public string spriteSheetName = "Eli Body Sheet";


    void LateUpdate()
    {
        print("Hello");
        var subSprites = Resources.LoadAll<Sprite>("Sprite_Sheets/Eli_test/" + spriteSheetName);
        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            Debug.Log("renderer= " + renderer + "\n");
            Debug.Log(renderer.sprite.name);
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);
            if (newSprite)
                renderer.sprite = newSprite;
        }
    }
}