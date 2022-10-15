using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPF_MVVM_Application.ViewModels;

namespace WPF_MVVM_Application.HostBuilders;

/// <summary>
/// Provides extension methods to inject viewmodels.
/// </summary>
public static class AddViewModelsHostBuilderExtensions {

    /// <summary>
    /// Injects the main window.
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder AddMainWindow(this IHostBuilder hostBuilder) {
        return hostBuilder.ConfigureServices(services => {

            services.AddSingleton<MainWindow>(services => new() { DataContext = services.GetRequiredService<MainViewModel>() });
            
        });
    }

    /// <summary>
    /// Injects the viewmodels.
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder) {
        return hostBuilder.ConfigureServices(services => {

            services.AddSingleton<MainViewModel>();
            services.AddTransient<IndexViewModel>();
            
        });
    }

}