using System.Xml.Serialization;
using Telt_Homework.Enums;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName = "password")]
public class Password : ObservableObject
{
    private PasswordType type;
    private string text = string.Empty;

    [XmlAttribute(AttributeName = "type")]
    public PasswordType Type
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