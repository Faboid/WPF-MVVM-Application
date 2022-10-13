using System.Windows;

namespace WPF_MVVM_Application.Commands.UI;

/// <summary>
/// Resizes the window. If it's <see cref="WindowState.Maximized"/>, it's set to <see cref="WindowState.Normal"/>; else, it's set to <see cref="WindowState.Maximized"/>.
/// </summary>
public class ResizeCommand : CommandBase {

    private readonly Window _window;

    public ResizeCommand(Window window) {
        _window = window;
    }

    public override void Execute(object? parameter) {
        _window.WindowState = _window.WindowState switch {
            WindowState.Maximized => WindowState.Normal,
            _ => WindowState.Maximized,
        };
    }

}
