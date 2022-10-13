using System;
using System.Threading;
using System.Windows.Input;

namespace WPF_MVVM_Application.Commands.Bases;

/// <summary>
/// Represents a generic command's framework.
/// </summary>
public abstract class CommandBase : ICommand, IDisposable {

    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute(object? parameter) {
        return true;
    }

    public abstract void Execute(object? parameter);

    protected void OnCanExecuteChanged() {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }


    //0 == false
    //1 == true
    private int _isDisposed = 0;
    protected virtual void Dispose(bool disposing) { }
    public void Dispose() {
        if(Interlocked.Exchange(ref _isDisposed, 1) == 0) {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
