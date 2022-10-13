using System.Windows;
using System.Windows.Input;
using WPF_MVVM_Application.Stores;

namespace WPF_MVVM_Application.ViewModels;

/// <summary>
/// The main viewmodel of the application. Stores data on the current view model and commands to interact with the window.
/// </summary>
public class MainViewModel : ViewModelBase {

    private readonly NavigationStore _navigationStore;
    public ViewModelBase? CurrentViewModel => _navigationStore.CurrentViewModel;

    public ICommand MinimizeCommand { get; }
    public ICommand ResizeCommand { get; }
    public ICommand CloseCommand { get; }

    public MainViewModel(NavigationStore navigationStore, Window mainWindow) {
        _navigationStore = navigationStore;
        MinimizeCommand = new MinimizeCommand(mainWindow);
        ResizeCommand = new ResizeCommand(mainWindow);
        CloseCommand = new CloseCommand(mainWindow);

        _navigationStore.CurrentViewModelChanged += OnCurrentViewChanged;
    }

    private void OnCurrentViewChanged() {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

}