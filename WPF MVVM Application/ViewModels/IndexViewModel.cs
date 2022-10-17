using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using WPF_MVVM_Application.Services;

namespace WPF_MVVM_Application.ViewModels;

/// <summary>
/// An index VM to provide an example of the usage of <see cref="ViewModelBase"/> and <see cref="ErrorsViewModel"/>.
/// </summary>
public class IndexViewModel : ViewModelBase, INotifyDataErrorInfo {

	private readonly INotificationService _notificationService;
	private readonly ErrorsViewModel _errorsViewModel = new();

	private string _name = "";
	public string Name {
		get { return _name; }
		set { SetAndRaise(nameof(Name), ref _name, value); }
	}

	private int _age;
	public int Age {
		get { return _age; }
		set { 
			SetAndRaise(nameof(Age), ref _age, value);
			_errorsViewModel.ClearErrors(nameof(Age));
			if(value < 13) {
				_errorsViewModel.AddError(nameof(Age), "You have to be at least 13 years old.");
			}
		}
	}

	public ICommand HelloCommand { get; }

    private void Greet() {
        _notificationService.Send($"Hello, {Name}!");
    }

	public IndexViewModel(INotificationService notificationService) {
		_notificationService = notificationService;
        HelloCommand = new RelayCommand(Greet);
		_errorsViewModel.ErrorsChanged += OnErrorsChanged;
		PropertyChanged += OnCanConfirmChanged;
    }

	public bool CanConfirm => !string.IsNullOrWhiteSpace(Name) && !HasErrors;
	private void OnCanConfirmChanged(object? sender, PropertyChangedEventArgs e) {
		//to avoid stackoverflow
		if(e.PropertyName != nameof(CanConfirm)) {
			OnPropertyChanged(nameof(CanConfirm));
		}
	}

	public bool HasErrors => _errorsViewModel.HasErrors;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    private void OnErrorsChanged(object? sender, DataErrorsChangedEventArgs e) {
        ErrorsChanged?.Invoke(this, e);
    }

    public IEnumerable GetErrors(string? propertyName) => _errorsViewModel.GetErrors(propertyName);

	protected override void Dispose(bool disposed) {
		_errorsViewModel.ErrorsChanged -= OnErrorsChanged;
		PropertyChanged -= OnCanConfirmChanged;
		
		base.Dispose(disposed);
	}
}