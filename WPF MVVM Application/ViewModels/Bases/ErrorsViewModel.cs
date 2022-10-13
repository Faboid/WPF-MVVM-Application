using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WPF_MVVM_Application.ViewModels.Bases;

public class ErrorsViewModel : INotifyDataErrorInfo
{

    private readonly Dictionary<string, List<string>> _propertyErrors = new();
    public bool HasErrors => _propertyErrors.Any();
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
        if (propertyName != null)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, new());
        }

        return Array.Empty<string>();
    }

    public void AddError(string propertyName, string errorMessage)
    {
        if (!_propertyErrors.ContainsKey(propertyName))
        {
            _propertyErrors.Add(propertyName, new());
        }

        _propertyErrors[propertyName].Add(errorMessage);
        OnErrorsChanged(propertyName);
    }

    public void ClearErrors(string propertyName)
    {
        if (_propertyErrors.Remove(propertyName))
        {
            OnErrorsChanged(propertyName);
        }
    }

    private void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new(propertyName));
    }

}
