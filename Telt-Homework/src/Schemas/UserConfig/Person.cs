using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName="person")]
public class PersonData { 

    [XmlElement(ElementName="acc")] 
    public List<UserAccount> Accounts { get; set; } 
}