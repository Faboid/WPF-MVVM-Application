using System;
using System.Threading.Tasks;
using WPF_MVVM_Application.Services;

namespace WPF_MVVM_Application.Commands.Bases;

/// <summary>
/// Executes the given <see cref="Func{TResult}"/> when executed.
/// </summary>
public class AsyncRelayCommand : AsyncCommandBase {

    private readonly Func<Task> _callback;

    public AsyncRelayCommand(Func<Task> callback) {
        _callback = callback;
    }

    public AsyncRelayCommand(Func<Task> callback, BusyService busyService) : base(busyService) {
        _callback = callback;
    }

    protected override Task ExecuteAsync(object? parameter) => _callback.Invoke();

}

/// <summary>
/// Executes the given <see cref="Func{T, TResult}"/> when executed.
/// </summary>
/// <typeparam name="T"></typeparam>
public class AsyncRelayCommand<T> : AsyncCommandBase {

    private readonly Func<T, Task> _callback;

    public AsyncRelayCommand(Func<T, Task> callback) {
        _callback = callback;
    }

    public AsyncRelayCommand(Func<T, Task> callback, BusyService busyService) : base(busyService) {
        _callback = callback;
    }

    public override bool CanExecute(object? parameter) {
        return (parameter == null || parameter is T) && base.CanExecute(parameter);
    }

    protected override Task ExecuteAsync(object? parameter) => _callback?.Invoke((T)parameter!)!;
}
