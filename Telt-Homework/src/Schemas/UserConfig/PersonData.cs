using System.Xml.Serialization;

namespace Telt_Homework.Schemas.UserConfig;

[XmlRoot(ElementName = "acc")]
public class PersonData : ObservableObject
{
    private string userName = string.Empty;
    private Password password = new();
    private int id;
    private int enabled;
    private bool isSelected;

    [XmlIgnore]
    public bool IsSelected
    {
        get => isSelected;
        set => SetProperty(ref isSelected, value);
    }

    [XmlElement(ElementName = "user_name")]
    public string UserName
    {
        get => userName;
        set => SetProperty(ref userName, value);
    }

    [XmlElement(ElementName = "password")]
    public Password Password
    {
        get => password;
        set
        {
            if (password != null)
            {
                password.PropertyChanged -= OnChildPropertyChanged;
            }
            if (SetProperty(ref password, value!) && value != null)
            {
                value.PropertyChanged += OnChildPropertyChanged;
            }
        }
    }

    [XmlAttribute(AttributeName = "id")]
    public int Id
    {
        get => id;
        set => SetProperty(ref id, value);
    }

    [XmlAttribute(AttributeName = "enabled")]
    public int Enabled
    {
        get => enabled;
        set => SetProperty(ref enabled, value);
    }

    private void OnChildPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Password));
    }
}