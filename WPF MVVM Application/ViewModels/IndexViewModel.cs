namespace WPF_MVVM_Application.ViewModels;

public class IndexViewModel : ViewModelBase {

    private string _helloWorld = "Hello world!";
    public string HelloWorld {
        get { return _helloWorld; }
        set { SetAndRaise(nameof(HelloWorld), ref _helloWorld, value); }
    }

}