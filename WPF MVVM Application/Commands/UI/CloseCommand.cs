using System.Windows;

namespace WPF_MVVM_Application.Commands.UI;

/// <summary>
/// Shuts down the window.
/// </summary>
public class CloseCommand : CommandBase {

    private readonly Window _window;

    public CloseCommand(Window window) {
        _window = window;
    }

    public override void Execute(object? parameter) {
        _window.Close();
    }

}
