using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName="person")]
public class PersonDataContainer { 

    [XmlElement(ElementName="acc")] 
    public List<PersonData> Accounts { get; set; } 
}