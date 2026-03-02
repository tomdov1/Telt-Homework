using System.Collections.ObjectModel;
using Telt_Homework.Main;
using Telt_Homework.Schemas.UserConfig;

namespace Telt_Homework.ViewModels;

public class MainViewModel
{
    public ObservableCollection<PersonData> UserData { get; set; }

    public MainViewModel()
    {
        UserData = new();
        foreach (var entry in ConfigLoader.LoadConfig().UserData.Accounts)
        {
            UserData.Add(entry);
        }
    }
}