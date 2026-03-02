using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName="config")]
public class Config { 

    [XmlElement(ElementName="version")] 
    public Version Version { get; set; } 

    [XmlElement(ElementName="person")] 
    public PersonData Person { get; set; } 

    [XmlElement(ElementName="uptime")] 
    public Uptime Uptime { get; set; } 
}