using System.Windows;
using Microsoft.Win32;
using Telt_Homework.ViewModels;

namespace Telt_Homework;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }

    private void BrowseConfig_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog
        {
            Title = "Select config file",
            Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
            CheckFileExists = true,
            CheckPathExists = true
        };

        if (dialog.ShowDialog() == true && DataContext is MainViewModel vm)
        {
            vm.ConfigPath = dialog.FileName;
        }
    }

    private void LoadConfig_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel vm)
        {
            vm.LoadConfig();
        }
    }
}
