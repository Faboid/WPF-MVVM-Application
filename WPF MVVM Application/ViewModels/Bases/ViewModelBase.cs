using System;
using System.ComponentModel;

namespace WPF_MVVM_Application.ViewModels.Bases;
public class ViewModelBase : INotifyPropertyChanged, IDisposable
{

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string? propertyName)
    {
        PropertyChanged?.Invoke(this, new(propertyName));
    }

    protected void SetAndRaise<T>(string name, ref T prop, T value)
    {
        prop = value;
        OnPropertyChanged(name);
    }

    private bool _isDisposed = false;
    public void Dispose()
    {
        if (!_isDisposed)
        {
            Dispose(_isDisposed);
        }
        _isDisposed = true;
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposed) { }

}