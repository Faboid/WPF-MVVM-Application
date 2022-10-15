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

    private bool _messageBoxVisibility = false;
    public bool MessageBoxVisibility { get => _messageBoxVisibility; set => SetAndRaise(nameof(MessageBoxVisibility), ref _messageBoxVisibility, value); }

    public ICommand CloseMessageCommand { get; }

    public MainViewModel(NavigationStore navigationStore, INotificationService notificationService) {
        _navigationStore = navigationStore;
        _notificationService = notificationService;
        CloseMessageCommand = new RelayCommand(CloseMessage);

        _navigationStore.CurrentViewModelChanged += OnCurrentViewChanged;
        _notificationService.NewMessage += OnNewMessage;
    }

    private void OnNewMessage(string message) {
        Message = message;
        MessageBoxVisibility = true;
    }

    private void CloseMessage() {
        Message = "";
        MessageBoxVisibility = false;
    }

    private void OnCurrentViewChanged() {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

    protected override void Dispose(bool disposed) {
        _notificationService.NewMessage -= OnNewMessage;
        _navigationStore.CurrentViewModelChanged -= OnCurrentViewChanged;
        base.Dispose(disposed);
    }

}