using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName="password")]
public class Password { 

    [XmlAttribute(AttributeName="type")] 
    public string Type { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}