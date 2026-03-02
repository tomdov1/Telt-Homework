using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName="acc")]
public class UserAccount { 

    [XmlElement(ElementName="user_name")] 
    public string UserName { get; set; } 

    [XmlElement(ElementName="password")] 
    public Password Password { get; set; } 

    [XmlAttribute(AttributeName="id")] 
    public int Id { get; set; } 

    [XmlAttribute(AttributeName="enabled")] 
    public int Enabled { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}