using System.Threading.Tasks;
using WPF_MVVM_Application.Services;

namespace WPF_MVVM_Application.Commands.Bases;

/// <summary>
/// Represents a linkable asynchronous command.
/// </summary>
public abstract class AsyncCommandBase : AsyncLinkableCommandBase {

    public AsyncCommandBase() { }
    public AsyncCommandBase(BusyService busyService) : base(busyService) { }

    public override async Task ExecuteLinkedAsync(object? parameter) {
        await ExecuteAsync(parameter);
    }

    protected abstract Task ExecuteAsync(object? parameter);

}
