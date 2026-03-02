using System.Xml.Serialization;
using Telt_Homework.Enums;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName="password")]
public class Password { 

    [XmlAttribute(AttributeName="type")] 
    public PasswordType Type { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}