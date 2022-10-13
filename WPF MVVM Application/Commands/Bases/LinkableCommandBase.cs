using WPF_MVVM_Application.Services;

namespace WPF_MVVM_Application.Commands.Bases;

/// <summary>
/// Provides the basic functionality of <see cref="CommandBase"/> and support for linking multiple commands:
/// </br> Linked commands can execute only one at a time.
/// </summary>
public abstract class LinkableCommandBase : CommandBase {

    private readonly BusyService _busyService;

    public LinkableCommandBase() : this(new()) { }
    protected LinkableCommandBase(BusyService busyService) {
        _busyService = busyService;
        _busyService.BusyChanged += OnCanExecuteChanged;
    }

    public override bool CanExecute(object? parameter) {
        return _busyService.IsFree && base.CanExecute(parameter);
    }

    public override sealed void Execute(object? parameter) {
        using var busy = _busyService.GetBusy();
        ExecuteLinked(parameter);
    }

    /// <summary>
    /// Defines the method to be called when the command is called.
    /// <br/> Commands that share <see cref="BusyService"/> can execute this method only one at a time.
    /// </summary>
    /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null"/>.</param>
    public abstract void ExecuteLinked(object? parameter);

    protected override void Dispose(bool disposing) {
        _busyService.BusyChanged -= OnCanExecuteChanged;
        base.Dispose(disposing);
    }
}