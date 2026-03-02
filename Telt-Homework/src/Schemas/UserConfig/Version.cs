using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName="version")]
public class Version { 

    [XmlAttribute(AttributeName="type")] 
    public string Type { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}