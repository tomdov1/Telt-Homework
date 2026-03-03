using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName = "version")]
public class Version : ObservableObject
{
    private string type;
    private string text;

    [XmlAttribute(AttributeName = "type")]
    public string Type
    {
        get => type;
        set => SetProperty(ref type, value);
    }

    [XmlText]
    public string Text
    {
        get => text;
        set => SetProperty(ref text, value);
    }
}