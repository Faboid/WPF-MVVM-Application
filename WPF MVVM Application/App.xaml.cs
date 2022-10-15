using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WPF_MVVM_Application.HostBuilders;
using WPF_MVVM_Application.Stores;
using WPF_MVVM_Application.ViewModels;

namespace WPF_MVVM_Application;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {

    private readonly IHost _host;

    public App() {

        _host = Host
            .CreateDefaultBuilder()
            .AddUIComponents()
            .AddStores()
            .AddViewModels()
            .AddMainWindow()
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e) {

        var startingVM = _host.Services.GetRequiredService<IndexViewModel>();
        _host.Services.GetRequiredService<NavigationStore>().CurrentViewModel = startingVM;

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();

        base.OnStartup(e);
    }
}
