using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Telt_Homework.Main;
using Telt_Homework.Schemas.UserConfig;
using Version = Telt_Homework.Schemas.UserConfig.Version;

namespace Telt_Homework.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private string configPath = string.Empty;
    private Version? version;
    private Uptime? uptime;
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public ObservableCollection<PersonData> UserData { get; set; } = new();
    
    public Uptime? Uptime
    {
        get => uptime;
        set
        {
            if (Equals(value, uptime))
            {
                return;
            }
            uptime = value;
            OnPropertyChanged();
        }
    }

    public Version? Version
    {
        get => version;
        set
        {
            if (Equals(value, version)) return;
            version = value;
            OnPropertyChanged();
        }
    }
    
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
        
        Config config = ConfigLoader.LoadConfig(ConfigPath);

        UserData.Clear();
        Version = config.Version;
        Uptime = config.Uptime;
        foreach (var entry in config.UserData.Accounts)
        {
            UserData.Add(entry);
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
