using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class pauseScript : MonoBehaviour {

    bool isPause = false;
    GameObject pauseMenu;
    Button menuButton;
    Button equipButton;
    Button currentButton;
    Button extra1;
    Button extra2;
    GameObject inventoryMenu;
    GameObject cursor;
    GameObject saver;
    bool test = true;

    texttype dialogue;

    Dpad dpad;

    Button[] menuLayout;
    int cursorPosition = 0;
    const int numButtons = 4;

    /*
     * [0] [1]
     * [2] [3]
     */

    void Start()
    {
        saver = GameObject.Find("GameSaver");
        dpad = GameObject.Find("DPad").GetComponent<Dpad>();

        dialogue = GameObject.Find("referencetext").GetComponent<texttype>();

        menuButton = GameObject.Find("Inventory").GetComponent<Button>();
        menuButton.onClick.AddListener(openInventory);
        equipButton = GameObject.Find("Change_Equip").GetComponent<Button>();
        equipButton.onClick.AddListener(changeEquip);
        extra1 = GameObject.Find("Extra_Button_1").GetComponent<Button>();
        extra2 = GameObject.Find("Extra_Button_2").GetComponent<Button>();
        extra2.onClick.AddListener(saveGame);

        menuLayout = new Button[numButtons] { menuButton, equipButton, extra1, extra2 };

        cursor = GameObject.Find("Cursor");
        cursorPosition = 0;

        pauseMenu = GameObject.Find("Main_Pause");
        pauseMenu.SetActive(false);
        
        inventoryMenu = GameObject.Find("Main_Inventory");
        inventoryMenu.SetActive(false);

        
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start")) && dialogue.active == false)
        {
            isPause = !isPause;
            if (isPause)
            {
                pauseMenu.SetActive(true);
                var pointer = new PointerEventData(EventSystem.current);
                ExecuteEvents.Execute(menuButton.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
                setCursorPosition(cursor.GetComponent<RectTransform>(), menuButton);
                Time.timeScale = 0;
            }
            else
            {
                inventoryMenu.SetActive(false);
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
        if (isPause)
            menu();
    }


    void menu()
    {
        var pointer = new PointerEventData(EventSystem.current);
        
        if (Input.GetButtonDown("A") || Input.GetKeyDown("z")){
            ExecuteEvents.Execute(menuLayout[cursorPosition].gameObject, pointer, ExecuteEvents.submitHandler);
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("a") || ((dpad.right == true || dpad.left == true)&& dpad.xpressed == false))
        {
            int oldPosition = cursorPosition;
            if (cursorPosition % 2 == 0)
                cursorPosition = oldPosition +1;
            else
                cursorPosition = oldPosition - 1;
            setCursorPosition(cursor.GetComponent<RectTransform>(), menuLayout[cursorPosition]);
            activateButton(menuLayout[cursorPosition], menuLayout[oldPosition]);
        }

        if (Input.GetKeyDown("s") || (dpad.down == true && dpad.ypressed == false))
        {
            int oldPosition = cursorPosition;
            if (cursorPosition >= numButtons - 2 && cursorPosition % 2 == 0)
                cursorPosition = 0;
            else if (cursorPosition >= numButtons - 2 && cursorPosition % 2 != 0)
                cursorPosition = 1;
            else
                cursorPosition = oldPosition + 2;

            setCursorPosition(cursor.GetComponent<RectTransform>(), menuLayout[cursorPosition]);
            activateButton(menuLayout[cursorPosition], menuLayout[oldPosition]);
        }

        if (Input.GetKeyDown("w") || (dpad.up == true && dpad.ypressed == false))
        {
            int oldPosition = cursorPosition;
            if (cursorPosition <= 1 && cursorPosition % 2 == 0)
                cursorPosition = numButtons -2;
            else if (cursorPosition <= 1 && cursorPosition % 2 != 0)
                cursorPosition = numButtons - 1;
            else
                cursorPosition = oldPosition -2;

            setCursorPosition(cursor.GetComponent<RectTransform>(), menuLayout[cursorPosition]);
            activateButton(menuLayout[cursorPosition], menuLayout[oldPosition]);
        }
    }

    void activateButton(Button newButton, Button oldButton)
    {
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(oldButton.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        ExecuteEvents.Execute(newButton.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
    }

    void setCursorPosition(RectTransform thiscursor, Button button)
    {
        cursor.GetComponent<Transform>().position = new Vector3(button.GetComponent<RectTransform>().position.x - thiscursor.rect.width, button.GetComponent<RectTransform>().position.y, button.GetComponent<RectTransform>().position.z);
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
    }
    void openInventory()
    {
        inventoryMenu.SetActive(true);
    }

    void changeEquip()
    {
        if (test == true)
        {
            Time.timeScale = .001f;
            var player = GameObject.Find("Eli");
            print(player);
            player.GetComponent<spriteInterchange>().setBody("test blue shirt");
            Time.timeScale = 0;
            test = false;
        }
        else
        {
            Time.timeScale = .001f;
            var player = GameObject.Find("Eli");
            print(player);
            player.GetComponent<spriteInterchange>().setBody("Eli Body Sheet");
            Time.timeScale = 0;
            test = true;
        }
    }

    void saveGame()
    {
        saver.GetComponent<SaveGame>().Save();
    }
}
