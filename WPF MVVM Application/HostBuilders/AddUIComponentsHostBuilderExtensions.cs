using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPF_MVVM_Application.Services;

namespace WPF_MVVM_Application.HostBuilders;

/// <summary>
/// Provides extension methods to inject UI-specific components.
/// </summary>
public static class AddUIComponentsHostBuilderExtensions {

    /// <summary>
    /// Injects UI-specific components.
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder AddUIComponents(this IHostBuilder hostBuilder) {
        return hostBuilder.ConfigureServices(services => {
            services.AddSingleton<INotificationService, NotificationService>();
        });
    }

}
