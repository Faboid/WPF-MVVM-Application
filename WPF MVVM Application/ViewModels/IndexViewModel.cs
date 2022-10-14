using System.Windows.Input;
using WPF_MVVM_Application.Services;

namespace WPF_MVVM_Application.ViewModels;

public class IndexViewModel : ViewModelBase {

    public ICommand HelloCommand { get; }

    public IndexViewModel(INotificationService notificationService) {
        HelloCommand = new RelayCommand(() => notificationService.Send("Hello!"));
    }

}