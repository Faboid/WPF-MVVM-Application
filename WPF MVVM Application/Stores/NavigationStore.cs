using System;

namespace WPF_MVVM_Application.Stores;

/// <summary>
/// A container for the current viewmodel.
/// </summary>
public class NavigationStore {

    private ViewModelBase? _currentViewModel;

    /// <summary>
    /// The current <see cref="ViewModelBase"/>.
    /// </summary>
    public ViewModelBase? CurrentViewModel {
        get => _currentViewModel;
        set {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    private void OnCurrentViewModelChanged() {
        CurrentViewModelChanged?.Invoke();
    }

    /// <summary>
    /// Raised when the current viewmodel changes.
    /// </summary>
    public event Action? CurrentViewModelChanged;

}
