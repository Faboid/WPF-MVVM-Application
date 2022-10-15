using System.Windows;
using System.Windows.Controls;

namespace WPF_MVVM_Application.Components;

/// <summary>
/// Connects the views and the viewmodels.
/// </summary>
public partial class ViewPresenter : UserControl {

    public ViewModelBase CurrentViewModel {
        get { return (ViewModelBase)GetValue(CurrentViewModelProperty); }
        set { SetValue(CurrentViewModelProperty, value); }
    }

    public static readonly DependencyProperty CurrentViewModelProperty =
        DependencyProperty.Register("CurrentViewModel", typeof(ViewModelBase), typeof(ViewPresenter), new PropertyMetadata(null));

    public ViewPresenter() {
        InitializeComponent();
    }
}
