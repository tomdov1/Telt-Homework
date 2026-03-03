using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName = "uptime")]
public class Uptime : ObservableObject
{
    private string type;
    private double text;

    [XmlAttribute(AttributeName = "type")]
    public string Type
    {
        get => type;
        set => SetProperty(ref type, value);
    }

    [XmlText]
    public double Text
    {
        get => text;
        set => SetProperty(ref text, value);
    }
}