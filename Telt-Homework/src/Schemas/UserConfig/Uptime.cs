using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName="uptime")]
public class Uptime { 

    [XmlAttribute(AttributeName="type")] 
    public string Type { get; set; } 

    [XmlText] 
    public double Text { get; set; } 
}