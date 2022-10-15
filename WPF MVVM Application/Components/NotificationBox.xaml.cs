using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_MVVM_Application.Components;
/// <summary>
/// A notification box that obscures the background.
/// </summary>
public partial class NotificationBox : UserControl {

    //keep these on top. The order with the property matters
    private static SolidColorBrush DefaultBoxBackground => new((Color)ColorConverter.ConvertFromString("#949494"));
    private static SolidColorBrush DefaultTextColor => new((Color)ColorConverter.ConvertFromString("#000000"));

    public Brush BoxBackground {
        get { return (Brush)GetValue(BoxBackgroundProperty); }
        set { SetValue(BoxBackgroundProperty, value); }
    }

    public Brush MessageColor {
        get { return (Brush)GetValue(MessageColorProperty); }
        set { SetValue(MessageColorProperty, value); }
    }

    public static readonly DependencyProperty BoxBackgroundProperty =
        DependencyProperty.Register("BoxBackground", typeof(Brush), typeof(NotificationBox), new PropertyMetadata(DefaultBoxBackground));

    public static readonly DependencyProperty MessageColorProperty =
        DependencyProperty.Register("MessageColor", typeof(Brush), typeof(NotificationBox), new PropertyMetadata(DefaultTextColor));

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
        Visibility = string.IsNullOrEmpty(MessageText) ? Visibility.Hidden : Visibility.Visible;
    }
    
    private void CloseButton_Click(object sender, RoutedEventArgs e) {
        Visibility = Visibility.Hidden;
        MessageText = "";
    }
}
