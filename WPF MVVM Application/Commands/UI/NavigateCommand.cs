using System;
using WPF_MVVM_Application.Services;

namespace WPF_MVVM_Application.Commands.UI;

/// <summary>
/// Used to navigate between <see cref="ViewModelBase"/>.
/// </summary>
/// <typeparam name="T"></typeparam>
public class NavigateCommand<T> : LinkableCommandBase where T : ViewModelBase {

    private readonly NavigationService<T> _navigationService;
    private readonly bool _disposeCurrent;

    public NavigateCommand(bool disposeCurrent, NavigationService<T> navigationService) {
        _navigationService = navigationService;
        _disposeCurrent = disposeCurrent;
    }

    public NavigateCommand(bool disposeCurrent, NavigationService<T> navigationService, BusyService busyService) : base(busyService) {
        _navigationService = navigationService;
        _disposeCurrent = disposeCurrent;
    }

    public override void ExecuteLinked(object? parameter) {
        _navigationService.Navigate(_disposeCurrent);
    }
}

/// <summary>
/// Used to navigate between <see cref="ViewModelBase"/> by giving an argument.
/// </summary>
/// <typeparam name="TViewModel">The viewmodel to navigate to.</typeparam>
/// <typeparam name="TArgument">The type of argument to give to the new viewmodel.</typeparam>
public class NavigateCommand<TViewModel, TArgument> : LinkableCommandBase where TViewModel : ViewModelBase {

    private readonly Func<TArgument> _getArgument;
    private readonly NavigationService<TViewModel, TArgument> _navigationService;
    private readonly bool _disposeCurrent;

    public NavigateCommand(Func<TArgument> lazyArgument, bool disposeCurrent, NavigationService<TViewModel, TArgument> navigationService) {
        _navigationService = navigationService;
        _disposeCurrent = disposeCurrent;
        _getArgument = lazyArgument;
    }

    public NavigateCommand(Func<TArgument> lazyArgument, bool disposeCurrent, NavigationService<TViewModel, TArgument> navigationService, BusyService busyService) : base(busyService) {
        _navigationService = navigationService;
        _disposeCurrent = disposeCurrent;
        _getArgument = lazyArgument;
    }

    public NavigateCommand(TArgument argument, bool disposeCurrent, NavigationService<TViewModel, TArgument> navigationService) {
        _navigationService = navigationService;
        _disposeCurrent = disposeCurrent;
        _getArgument = () => argument;
    }

    public NavigateCommand(TArgument argument, bool disposeCurrent, NavigationService<TViewModel, TArgument> navigationService, BusyService busyService) : base(busyService) {
        _navigationService = navigationService;
        _disposeCurrent = disposeCurrent;
        _getArgument = () => argument;
    }

    public override void ExecuteLinked(object? parameter) {
        _navigationService.Navigate(_getArgument.Invoke(), _disposeCurrent);
    }
}