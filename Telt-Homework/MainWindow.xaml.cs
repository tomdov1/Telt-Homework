using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Win32;
using Telt_Homework.ViewModels;

namespace Telt_Homework;

public partial class MainWindow : Window
{
    private string lastSortProperty = string.Empty;
    private ListSortDirection lastSortDirection = ListSortDirection.Ascending;

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

    private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not GridViewColumnHeader header)
        {
            return;
        }

        string? sortProperty = header.Tag as string;
        if (string.IsNullOrWhiteSpace(sortProperty))
        {
            return;
        }

        ListSortDirection direction = ListSortDirection.Ascending;
        if (sortProperty == lastSortProperty && lastSortDirection == ListSortDirection.Ascending)
        {
            direction = ListSortDirection.Descending;
        }

        ICollectionView view = CollectionViewSource.GetDefaultView(((MainViewModel)DataContext).UserData);
        view.SortDescriptions.Clear();
        view.SortDescriptions.Add(new SortDescription(sortProperty, direction));
        view.Refresh();

        lastSortProperty = sortProperty;
        lastSortDirection = direction;
    }
}
