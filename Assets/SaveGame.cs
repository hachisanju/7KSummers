using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class SaveGame : MonoBehaviour {

    TimeOfDay TOD;
    status save;

    private static string dirPath = Application.dataPath + "/Settings/";

    // Use this for initialization
    void Start () {
        save = new status();
        TOD = GameObject.Find("Day").GetComponent<TimeOfDay>();
        Load();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Save()
    {
        save.currentTime = TOD.getTime();
        save.currentHour = TOD.currentHour;
        save.currentMinute = TOD.currentMinutes;
        XmlSerializer serializer = new XmlSerializer(typeof(status));
        StreamWriter writer = new StreamWriter("status.xml");
        serializer.Serialize(writer.BaseStream, save);
        writer.Close();
    }

    public void Load()
    {

        var deserializer = new XmlSerializer(typeof(status));
        var stream = new FileStream("status.xml", FileMode.Open);
        save = deserializer.Deserialize(stream) as status;
        stream.Close();

        print(save.currentTime);

        TOD.setTime(save.currentTime);
        TOD.currentHour = save.currentHour;
        TOD.currentMinutes = save.currentMinute;
        TOD.Loaded();
        print(TOD.getTime());
        print(TOD.currentHour);
        print(TOD.currentMinutes);
    }
}
