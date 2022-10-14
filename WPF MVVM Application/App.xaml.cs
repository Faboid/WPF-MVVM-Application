using System.Windows;
using WPF_MVVM_Application.Services;
using WPF_MVVM_Application.Stores;
using WPF_MVVM_Application.ViewModels;

namespace WPF_MVVM_Application;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {

    private readonly NavigationStore _navigationStore;
    private readonly INotificationService _notificationService;

    public App() {
        _navigationStore = new();
        _notificationService = new NotificationService();
    }

    protected override void OnStartup(StartupEventArgs e) {

        MainWindow = new MainWindow();

        MainWindow.DataContext = new MainViewModel(_navigationStore, MainWindow, _notificationService);
        _navigationStore.CurrentViewModel = new IndexViewModel(_notificationService);
        MainWindow.Show();

        base.OnStartup(e);
    }
}
