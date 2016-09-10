using UnityEngine;
using System.Collections;

public class TimeOfDay : MonoBehaviour
{

    private int dayLength;   //in minutes
    private int dayStart;
    private int nightStart;   //also in minutes
    private int currentTime;
    public float cycleSpeed;
    private bool isDay;
    private Vector3 sunPosition;
    public GameObject sun;
    public GameObject streetLights;
    public int currentHour;
    public int currentMinutes;



    // Day and Night Script for 2d,
    // Unity needs one empty GameObject (earth) and one Light (sun)
    // make the sun a child of the earth
    // reset the earth position to 0,0,0 and move the sun to -200,0,0
    // attach script to sun
    // add sun and earth to script publics
    // set sun to directional light and y angle to 90


    void Start()
    {
            dayLength = 1440;
            dayStart = 300;
            nightStart = 1200;
            //currentTime = 720;
        
    }

    public void Loaded()
    {
        StartCoroutine(Time());
    }

    void Update()
    {

        if (currentTime > 0 && currentTime < dayStart)
        {
            isDay = false;
            streetLights.GetComponent<Light>().enabled = true;
            //sun.GetComponent<Light>().intensity = 0;

        }
        else if (currentTime >= dayStart && currentTime < nightStart)
        {
            isDay = true;
            streetLights.GetComponent<Light>().enabled = false;
            //sun.GetComponent<Light>().intensity = 1;
        }
        else if (currentTime >= nightStart && currentTime < dayLength)
        {
            isDay = false;
            streetLights.GetComponent<Light>().enabled = true;
            //sun.GetComponent<Light>().intensity = 0;
        }
        else if (currentTime >= dayLength)
        {
            currentTime = 0;
        }
        float currentTimeF = currentTime;
        float dayLengthF = dayLength;
        if (currentHour <= 12)
        {
            sun.GetComponent<Light>().intensity = .083f * currentHour;
        }
        else
        {
            sun.GetComponent<Light>().intensity = .083f * (12 - (currentHour - 12));
        }
        //earth.transform.eulerAngles = new Vector3(0, 0, (-(currentTimeF / dayLengthF) * 360) + 90);
    }

    public void setTime(int x)
    {
        currentTime = x;
    }

    public int getTime()
    {
        return currentTime;
    }

    IEnumerator Time()
    {
        
        while (true)
        {
            currentTime += 1;
            int hours = Mathf.RoundToInt(currentTime / 60);
            currentHour = hours;
            int minutes = currentTime % 60;
            currentMinutes = minutes;
            //Debug.Log(hours + ":" + minutes);
            yield return new WaitForSeconds(1F / cycleSpeed);
        }
    }
}