using System;

namespace WPF_MVVM_Application.Services;

/// <summary>
/// Handles coordination between objects by giving a shared <see cref="IsBusy"/>, ensuring only one object can be activated at the same time.
/// </summary>
public class BusyService {

    public event Action? BusyChanged;
    public event Action<bool>? BusyChangedTo;

    private bool _isBusy = false;

    /// <summary>
    /// Returns whether the object is currently busy.
    /// </summary>
    public bool IsBusy {
        get => _isBusy;
        private set {
            _isBusy = value;
            BusyChanged?.Invoke();
            BusyChangedTo?.Invoke(_isBusy);
        }
    }

    /// <summary>
    /// Whether it's not busy.
    /// </summary>
    public bool IsFree => !IsBusy;

    public BusyHandler GetBusy() {
        IsBusy = true;
        return new BusyHandler(this);
    }

    /// <summary>
    /// Handles setting <see cref="IsBusy"/> back to <see langword="false"/> once it's disposed.
    /// </summary>
    public struct BusyHandler : IDisposable {

        private bool _isDisposed = false;
        private readonly BusyService _busyService;

        internal BusyHandler(BusyService busyService) {
            _busyService = busyService;
        }

        public void Dispose() {
            if(!_isDisposed) {
                _busyService.IsBusy = false;
                _isDisposed = true;
            }
        }
    }

}