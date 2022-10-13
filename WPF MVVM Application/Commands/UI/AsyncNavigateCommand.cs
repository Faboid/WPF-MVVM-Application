using System;
using System.Threading.Tasks;
using WPF_MVVM_Application.Commands.Bases;
using WPF_MVVM_Application.Services;
using WPF_MVVM_Application.ViewModels.Bases;

namespace WPF_MVVM_Application.Commands.UI;

/// <summary>
/// Provides a method to generate an argument asynchonously to be passed to a new generated view. The current view will shift to <see cref="TViewModel"/> when executed.
/// </summary>
/// <typeparam name="TViewModel">The viewmodel to navigate to.</typeparam>
/// <typeparam name="TArgument">The argument to be passed to the viewmodel.</typeparam>
public class AsyncNavigateCommand<TViewModel, TArgument> : AsyncCommandBase where TViewModel : ViewModelBase
{

    private readonly Func<Task<TArgument>> _getArgumentAsync;
    private readonly NavigationService<TViewModel, TArgument> _navigationService;
    private readonly bool _disposeCurrent;

    public AsyncNavigateCommand(Func<Task<TArgument>> lazyArgumentAsync, bool disposeCurrent, NavigationService<TViewModel, TArgument> navigationService)
    {
        _navigationService = navigationService;
        _disposeCurrent = disposeCurrent;
        _getArgumentAsync = lazyArgumentAsync;
    }

    public AsyncNavigateCommand(Func<Task<TArgument>> lazyArgumentAsync, bool disposeCurrent, NavigationService<TViewModel, TArgument> navigationService, BusyService busyService) : base(busyService)
    {
        _navigationService = navigationService;
        _disposeCurrent = disposeCurrent;
        _getArgumentAsync = lazyArgumentAsync;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var argument = await _getArgumentAsync.Invoke();
        _navigationService.Navigate(argument, _disposeCurrent);
    }
}