using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClockMonitor : MonoBehaviour {

    GameObject time;
    int hour;
    string ampm;

	// Use this for initialization
	void Start () {
        time = GameObject.Find("Day");
	}
	
	// Update is called once per frame
	void Update () {
        string currentTime = "";
        if (time.GetComponent<TimeOfDay>().currentHour > 12)
        {
            hour = time.GetComponent<TimeOfDay>().currentHour - 12;
            ampm = "PM";
        }
        else if (time.GetComponent<TimeOfDay>().currentHour == 12)
        {
            hour = time.GetComponent<TimeOfDay>().currentHour;
            ampm = "PM";
        }
        else if (time.GetComponent<TimeOfDay>().currentHour == 0)
        {
            hour = 12;
            ampm = "AM";
        }
        else
        {
            ampm = "AM";
            hour = time.GetComponent<TimeOfDay>().currentHour;
        }
        if (time.GetComponent<TimeOfDay>().currentMinutes < 10)
            currentTime = hour + ":0" + time.GetComponent<TimeOfDay>().currentMinutes + ampm;
        else
            currentTime = hour + ":" + time.GetComponent<TimeOfDay>().currentMinutes + ampm;
        GetComponent<Text>().text = currentTime;

    }
}
