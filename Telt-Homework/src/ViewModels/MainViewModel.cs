using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Telt_Homework.Enums;
using Telt_Homework.Main;
using Telt_Homework.Schemas.UserConfig;
using Version = Telt_Homework.Schemas.UserConfig.Version;

namespace Telt_Homework.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private string configPath = string.Empty;
    private Version? version;
    private Uptime? uptime;
    private bool isDirty;

    public event PropertyChangedEventHandler? PropertyChanged;


    public ObservableCollection<PersonData> UserData { get; set; }
    public IEnumerable<PasswordType> PasswordTypes => Enum.GetValues<PasswordType>();

    public MainViewModel()
    {
        UserData = new ObservableCollection<PersonData>();
        UserData.CollectionChanged += OnUserDataChanged;
    }

    public bool IsDirty
    {
        get => isDirty;
        set
        {
            if (isDirty == value)
            {
                return;
            }
            isDirty = value;
            OnPropertyChanged();
        }
    }


    public Uptime? Uptime
    {
        get => uptime;
        set
        {
            if (Equals(value, uptime))
            {
                return;
            }
            if (uptime != null)
            {
                uptime.PropertyChanged -= OnChildPropertyChanged;
            }
            uptime = value;
            if (uptime != null)
            {
                uptime.PropertyChanged += OnChildPropertyChanged;
            }
            OnPropertyChanged();
            IsDirty = true;
        }
    }

    public Version? Version
    {
        get => version;
        set
        {
            if (Equals(value, version))
            {
                return;
            }
            if (version != null)
            {
                version.PropertyChanged -= OnChildPropertyChanged;
            }
            version = value;
            if (version != null)
            {
                version.PropertyChanged += OnChildPropertyChanged;
            }
            OnPropertyChanged();
            IsDirty = true;
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


        IsDirty = false;
    }

    public void SaveConfig()
    {
        if (string.IsNullOrWhiteSpace(ConfigPath) || Version == null || Uptime == null)
        {
            return;
        }

        Config config = new()
        {
            Version = this.Version,
            Uptime = this.Uptime,
            UserData = new() { Accounts = UserData.ToList() }
        };

        ConfigLoader.SaveConfig(config, ConfigPath);
        IsDirty = false;
    }

    private void OnChildPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        IsDirty = true;
    }

    private void OnUserDataChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (PersonData item in e.NewItems)
            {
                item.PropertyChanged += OnChildPropertyChanged;
            }
        }

        if (e.OldItems != null)
        {
            foreach (PersonData item in e.OldItems)
            {
                item.PropertyChanged -= OnChildPropertyChanged;
            }
        }

        IsDirty = true;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
