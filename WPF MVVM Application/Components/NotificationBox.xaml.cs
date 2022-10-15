using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPF_MVVM_Application.Components;
/// <summary>
/// Interaction logic for NotificationBox.xaml
/// </summary>
public partial class NotificationBox : UserControl {

    public string MessageText {
        get { return (string)GetValue(MessageTextProperty); }
        set { SetValue(MessageTextProperty, value); }
    }

    public static readonly DependencyProperty MessageTextProperty =
        DependencyProperty.Register("MessageText", typeof(string), typeof(NotificationBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, MessageTextChanged, null, false, UpdateSourceTrigger.PropertyChanged));

    private static void MessageTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        if(d is NotificationBox box) {
            box.SetVisibility();
        }
    }

    public NotificationBox() {
        InitializeComponent();
        Visibility = Visibility.Hidden;
    }

    private void SetVisibility() {
        if(string.IsNullOrEmpty(MessageText)) {
            Visibility = Visibility.Hidden;
        } else {
            Visibility = Visibility.Visible;
        }
    }
    
    private void CloseButton_Click(object sender, RoutedEventArgs e) {
        Visibility = Visibility.Hidden;
        MessageText = "";
    }
}
