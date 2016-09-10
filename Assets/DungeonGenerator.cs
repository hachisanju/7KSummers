using UnityEngine;
using System.Collections;

public class DungeonGenerator : MonoBehaviour {



    
    bool Good2Go = false;
    string cellname = "Dungeon_Cell ";
    string currentCellName;

    public static int MAX_SIZE = 4;

    public struct Constraints
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
    }

    public Constraints[,] dungoConstraints = new Constraints[MAX_SIZE, MAX_SIZE];
    public GameObject[,] dungo = new GameObject[MAX_SIZE, MAX_SIZE];

    // Use this for initialization
    void Start () {
        int currentCell = 0;
        int i = 0;
        int j = 0;
        GameObject o;

        //foreach (GameObject o in GameObject.FindObjectsOfType(typeof(GameObject)))
        for (int iterator = 0; iterator < 16; iterator++)
        {
            Good2Go = false;

            currentCellName = cellname + currentCell.ToString();


            o = GameObject.Find(currentCellName);

            if (o.tag == "DungeonCell")
            {
                //dungo[i, j] = o;
                //Debug.Log("i" + i + "j" + j);


                if (j == 0)
                {
                    while (Good2Go == false)
                    {
                        Good2Go = true;
                        int rando = Random.Range(1, 17);
                        dungoConstraints[i, j] = SetConstraints(rando);
                        string prefabName = "Maps/Dungeon_Cell " + rando.ToString();
                        
                        GameObject map = (GameObject)Instantiate(Resources.Load<GameObject>(prefabName), o.transform.position, o.transform.rotation);
                        Destroy(o);
                        o = map;
                        if (dungoConstraints[i, j].up == true)
                            Good2Go = false;
                        if (i == 0 && dungoConstraints[i, j].left == true)
                            Good2Go = false;
                        else if (dungoConstraints[i, j].left == true && dungoConstraints[i - 1, j].right == false)
                            Good2Go = false;
                        if (i == MAX_SIZE - 1 && dungoConstraints[i, j].right == true)
                            Good2Go = false;
                        if (i > 0 && dungoConstraints[i, j].left == false && dungoConstraints[i - 1, j].right == true)
                            Good2Go = false;
                        if (Good2Go == true)
                            Debug.Log(rando);
                    }//While
                    Debug.Log("UP: " + dungoConstraints[i, j].up + "DOWN: " + dungoConstraints[i, j].down + "LEFT: " + dungoConstraints[i, j].left + "RIGHT: " + dungoConstraints[i, j].right);
                    
                }//If    

                else if (j < MAX_SIZE -1)
                {
                    Debug.Log("i= " + i + "j = " + j);
                    
                    while (Good2Go == false)
                    {
                        Good2Go = true;
                        Debug.Log(Good2Go);
                        //Good2Go = true;
                        int rando = Random.Range(1, 17);
                        dungoConstraints[i, j] = SetConstraints(rando);

                        //Debug.Log(dungoConstraints[i, j - 1].down);
                        
                        Debug.Log(dungoConstraints[i, j].up);

                        string prefabName = "Maps/Dungeon_Cell " + rando.ToString();
                        Debug.Log(rando);
                        Debug.Log(prefabName);
                        
                        if (i == 0 && dungoConstraints[i, j].left == true)
                            Good2Go = false;
                         else if (dungoConstraints[i, j].left == true && dungoConstraints[i - 1, j].right == false)
                             Good2Go = false;
                        if (i > 0 && dungoConstraints[i, j].left == false && dungoConstraints[i - 1, j].right == true)
                            Good2Go = false;
                        /*else if ((dungoConstraints[i, j].left == true && dungoConstraints[i - 1, j].right == false) || (dungoConstraints[i, j].left == false && dungoConstraints[i - 1, j].right == true))
                            Good2Go = false;*/
                        if (dungoConstraints[i, j - 1].down == true && dungoConstraints[i, j].up == false)
                            Good2Go = false;
                        else if (dungoConstraints[i, j - 1].down == false && dungoConstraints[i, j].up == true)
                            Good2Go = false;
                        if (i == MAX_SIZE - 1 && dungoConstraints[i, j].right == true)
                            Good2Go = false;
                        if (Good2Go == true)
                        {
                            GameObject map = (GameObject)Instantiate(Resources.Load<GameObject>(prefabName), o.transform.position, o.transform.rotation);
                            Destroy(o);
                            //o = map;
                        }

                    }//While

                }//If   
                else if (j == MAX_SIZE -1)
                {
                    //Debug.Log("i= " + i + "j = " + j);

                    while (Good2Go == false)
                    {
                        Good2Go = true;

                        int rando = Random.Range(0, 17);
                        dungoConstraints[i, j] = SetConstraints(rando);

                        string prefabName = "Maps/Dungeon_Cell " + rando.ToString();

                        if (i == 0 && dungoConstraints[i, j].left == true)
                            Good2Go = false;
                        else if (dungoConstraints[i, j].left == true && dungoConstraints[i - 1, j].right == false)
                            Good2Go = false;
                        if ( i > 0 && dungoConstraints[i, j].left == false && dungoConstraints[i - 1, j].right == true)
                            Good2Go = false;
                        if (dungoConstraints[i, j - 1].down == true && dungoConstraints[i, j].up == false)
                            Good2Go = false;
                        else if (dungoConstraints[i, j - 1].down == false && dungoConstraints[i, j].up == true)
                            Good2Go = false;
                        if (i == MAX_SIZE - 1 && dungoConstraints[i, j].right == true)
                            Good2Go = false;
                        if (dungoConstraints[i, j].down == true)
                            Good2Go = false;

                        if (Good2Go == true)
                        {
                            GameObject map = (GameObject)Instantiate(Resources.Load<GameObject>(prefabName), o.transform.position, o.transform.rotation);
                            Destroy(o);
                            Debug.Log("UP: " + dungoConstraints[i, j].up + "DOWN: " + dungoConstraints[i, j].down + "LEFT: " + dungoConstraints[i, j].left + "RIGHT: " + dungoConstraints[i, j].right);
                            Debug.Log(prefabName);
                            //o = map;
                        }

                    }//While

                }//If   
                dungo[i, j] = o;
                if (i < 3)
                    i++;
                else
                {
                    i = 0;
                    j++;
                }//Else        
            }//If
            currentCell++;
        }//For
    }
	
	// Update is called once per frame
	void Update () {
        // Debug.Log(dungo[0, 7]);
        if (Input.GetKeyDown("q"))
            Rando_Gen();
	}

    Constraints SetConstraints(int x)
    {
        Constraints ret = new Constraints();
        switch (x)
        {
            case 0:
                ret.up = false;
                ret.down = false;
                ret.left = false;
                ret.right = false;
                break;
            case 1:
                ret.up = true;
                ret.down = true;
                ret.left = true;
                ret.right = true;
                break;
            case 2:
                ret.up = false;
                ret.down = true;
                ret.left = true;
                ret.right = true;
                break;
            case 3:
                ret.up = false;
                ret.down = false;
                ret.left = true;
                ret.right = true;
                break;
            case 4:
                ret.up = false;
                ret.down = false;
                ret.left = true;
                ret.right = true;
                break;
            case 5:
                ret.up = false;
                ret.down = false;
                ret.left = true;
                ret.right = false;
                break;
            case 6:
                ret.up = false;
                ret.down = true;
                ret.left = false;
                ret.right = false;
                break;
            case 7:
                ret.up = true;
                ret.down = false;
                ret.left = true;
                ret.right = true;
                break;
            case 8:
                ret.up = true;
                ret.down = false;
                ret.left = false;
                ret.right = true;
                break;
            case 9:
                ret.up = true;
                ret.down = false;
                ret.left = true;
                ret.right = false;
                break;
            case 10:
                ret.up = true;
                ret.down = false;
                ret.left = false;
                ret.right = false;
                break;
            case 11:
                ret.up = true;
                ret.down = true;
                ret.left = false;
                ret.right = true;
                break;
            case 12:
                ret.up = true;
                ret.down = true;
                ret.left = true;
                ret.right = false;
                break;
            case 13:
                ret.up = false;
                ret.down = true;
                ret.left = true;
                ret.right = false;
                break;
            case 14:
                ret.up = true;
                ret.down = false;
                ret.left = true;
                ret.right = true;
                break;
            case 15:
                ret.up = true;
                ret.down = false;
                ret.left = false;
                ret.right = true;
                break;
            case 16:
                ret.up = true;
                ret.down = true;
                ret.left = false;
                ret.right = false;
                break;
        }
        return ret;
    }

    void Rando_Gen()
    {
        int currentCell = 0;
        int i = 0;
        int j = 0;
        GameObject o;

        //foreach (GameObject o in GameObject.FindObjectsOfType(typeof(GameObject)))
        for (int iterator = 0; iterator < 16; iterator++)
        {
            Good2Go = false;

            currentCellName = cellname + currentCell.ToString();


            o = dungo[i, j];

            if (o.tag == "DungeonCell")
            {
                //dungo[i, j] = o;
               // Debug.Log("i" + i + "j" + j);

                    while (Good2Go == false)
                    {
                        int rando = Random.Range(1, 17);
                        dungoConstraints[i, j] = SetConstraints(rando);
                        //o.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Maps/Dungeon Generation")[rando];
                        //GameObject mapObject = (GameObject)Instantiate(destroyedCarPrefab, carGameObject.transform.position, carGameObject.transform.rotation);
                        string prefabName = "Maps/Dungeon_Cell " + rando.ToString();
                        Debug.Log(prefabName);
                        GameObject map = (GameObject)Instantiate(Resources.Load<GameObject>(prefabName), o.transform.position, o.transform.rotation);
                        Destroy(o);
                        o = map;
                        if (dungoConstraints[i, j].up == false)
                            Good2Go = true;
                        if (i == 0 && dungoConstraints[i, j].left == true)
                            Good2Go = false;
                        Good2Go = true;
                        /*else if (dungoConstraints[i - 1, j].right == true && dungoConstraints[i, j].left == false)
                            Good2Go = false;*/
                    }//While
                }//If    
                dungo[i, j] = o;
                if (i < 7)
                    i++;
                else
                {
                    i = 0;
                    j++;
                }//Else        
            }//If
            currentCell++;
        }//For
}
