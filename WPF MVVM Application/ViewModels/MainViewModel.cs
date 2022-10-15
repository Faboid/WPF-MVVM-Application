using System.Windows.Input;
using WPF_MVVM_Application.Services;
using WPF_MVVM_Application.Stores;

namespace WPF_MVVM_Application.ViewModels;

/// <summary>
/// The main viewmodel of the application. Stores data on the current view model, the notification mechanism, and commands to interact with the window.
/// </summary>
public class MainViewModel : ViewModelBase {

    private readonly INotificationService _notificationService;
    private readonly NavigationStore _navigationStore;
    public ViewModelBase? CurrentViewModel => _navigationStore.CurrentViewModel;

    private string _message = "";
    public string Message { get => _message; set => SetAndRaise(nameof(Message), ref _message, value); }

    public MainViewModel(NavigationStore navigationStore, INotificationService notificationService) {
        _navigationStore = navigationStore;
        _notificationService = notificationService;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewChanged;
        _notificationService.NewMessage += SetMessage;
    }

    private void SetMessage(string text) => Message = text;

    private void OnCurrentViewChanged() {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

    protected override void Dispose(bool disposed) {
        _notificationService.NewMessage -= SetMessage;
        _navigationStore.CurrentViewModelChanged -= OnCurrentViewChanged;
        base.Dispose(disposed);
    }

}