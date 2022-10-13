using System;
using WPF_MVVM_Application.Stores;
using WPF_MVVM_Application.ViewModels.Bases;

namespace WPF_MVVM_Application.Services;

/// <summary>
/// Provides methods to navigate to <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The viewmodel to navigate to.</typeparam>
public class NavigationService<T> where T : ViewModelBase {

    private readonly NavigationStore _navigationStore;
    private readonly Func<T> _navigationFunction;

    public NavigationService(NavigationStore navigationStore, Func<T> navigationFunction) {
        _navigationStore = navigationStore;
        _navigationFunction = navigationFunction;
    }

    /// <summary>
    /// Navigates to <typeparamref name="T"/>.
    /// </summary>
    /// <param name="disposeCurrent">Whether the current viewmodel should be disposed.</param>
    public void Navigate(bool disposeCurrent = true) {
        if(disposeCurrent) {
            _navigationStore.CurrentViewModel?.Dispose();
        }
        var newVM = _navigationFunction.Invoke();
        _navigationStore.CurrentViewModel = newVM;
    }

}

/// <summary>
/// Provides methods to navigate to <typeparamref name="TViewModel"/>, by giving it a <typeparamref name="TArgument"/>.
/// </summary>
/// <typeparam name="TViewModel">The viewmodel to navigate to.</typeparam>
/// <typeparam name="TArgument">The argument type to give to the viewmodel.</typeparam>
public class NavigationService<TViewModel, TArgument> where TViewModel : ViewModelBase {

    private readonly NavigationStore _navigationStore;
    private readonly Func<TArgument, TViewModel> _navigationFunction;

    public NavigationService(NavigationStore navigationStore, Func<TArgument, TViewModel> navigationFunction) {
        _navigationStore = navigationStore;
        _navigationFunction = navigationFunction;
    }

    /// <summary>
    /// Navigates to <typeparamref name="TViewModel"/> by giving it <typeparamref name="TArgument"/>.
    /// </summary>
    /// <param name="argument">The argument given to the <see cref="Func{T, TResult}"/> returning the viewmodel.</param>
    /// <param name="disposeCurrent">Whether the current viewmodel should be disposed.</param>
    public void Navigate(TArgument argument, bool disposeCurrent = true) {
        if(disposeCurrent) {
            _navigationStore.CurrentViewModel?.Dispose();
        }
        var newVM = _navigationFunction.Invoke(argument);
        _navigationStore.CurrentViewModel = newVM;
    }

}
