using System.Windows;
using WPF_MVVM_Application.Stores;
using WPF_MVVM_Application.ViewModels;

namespace WPF_MVVM_Application;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {

    public App() {

    }

    protected override void OnStartup(StartupEventArgs e) {

        MainWindow = new MainWindow();

        var navigationStore = new NavigationStore();
        MainWindow.DataContext = new MainViewModel(navigationStore, MainWindow);
        navigationStore.CurrentViewModel = new IndexViewModel();
        MainWindow.Show();

        base.OnStartup(e);
    }
}
