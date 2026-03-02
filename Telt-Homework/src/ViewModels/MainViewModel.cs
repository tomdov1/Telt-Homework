using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Telt_Homework.Main;
using Telt_Homework.Schemas.UserConfig;

namespace Telt_Homework.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<PersonData> UserData { get; set; } = new();

    private string configPath = string.Empty;
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public string ConfigPath
    {
        get => configPath;
        set
        {
            if (value == configPath)
            {
                return;
            }
            configPath = value;
            OnPropertyChanged();
        }
    }

    public void LoadConfig()
    {
        if (string.IsNullOrWhiteSpace(ConfigPath))
        {
            return;
        }

        UserData.Clear();
        foreach (var entry in ConfigLoader.LoadConfig(ConfigPath).UserData.Accounts)
        {
            UserData.Add(entry);
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
