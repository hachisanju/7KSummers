using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("status")]
public class status {
    [XmlAttribute("TOD")]
    public int currentTime;

    [XmlAttribute("Hour")]
    public int currentHour;

    [XmlAttribute("Minute")]
    public int currentMinute;
}
