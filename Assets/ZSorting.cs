using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZSorting : MonoBehaviour {
    //public object[] obj;
    public int i = 0;
    //public SortedList<object, float> obj = new SortedList<object, float>();
    //List<GameObject> objList = new List<GameObject>();

    // Use this for initialization
    void Start () {
       // int i = 0;
        foreach (GameObject o in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
           /* Vector3 zzz = new Vector3(o.transform.position.x, o.transform.position.y, i);
            if (o.tag == "Player" || o.tag == "Enemy" || o.tag == "NPC")
            {
                Debug.Log(zzz.z);
                i++;
                //o.GetComponent<Transform>().position.Set(zzz.x, zzz.y, zzz.z);
                o.transform.position = zzz;*/
          //  }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        //    obj = Object.FindObjectsOfType(typeof(GameObject));
        //   objList.Sort((x,y)=>x.transform.position.y.CompareTo(y.transform.position.y));
        //  Debug.Log(objList.);
        
        foreach (GameObject o in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (o.tag == "Player" || o.tag == "NPC")
            {
                var children = o.GetComponentsInChildren<SpriteRenderer>();

                children[0].GetComponent<SpriteRenderer>().sortingOrder = (int)((1.0f / (children[1].transform.position.y - (children[1].bounds.size.y / 2.0f))) * 100000000.0f);

            }
            if (o.tag == "Enemy" || o.tag == "FlatNPC" || o.tag == "Building")
            {

                //o.GetComponent<SpriteRenderer>().sortingOrder = (int)((1 / (o.transform.position.y-(o.GetComponent<SpriteRenderer>().bounds.size.y/o.transform.localScale.y))) * 100);
                o.GetComponent<SpriteRenderer>().sortingOrder = (int)((1.0f / (o.transform.position.y - (o.GetComponent<SpriteRenderer>().bounds.size.y / 2.0f))) * 100000000.0f);
               // o.GetComponent<SpriteRenderer>().sortingOrder = (int)((1.0f / (o.GetComponent<SpriteRenderer>().bounds.min.y)) * 100000.0f);
            }

            else if (o.tag == "Building")
            {
                o.GetComponent<SpriteRenderer>().sortingOrder = (int)((1.0f / (o.GetComponent<SpriteRenderer>().bounds.min.y)) * 100000000.0f);
            }
        }
    }
}
