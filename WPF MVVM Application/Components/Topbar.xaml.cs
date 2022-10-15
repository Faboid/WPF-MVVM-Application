using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_MVVM_Application.Components;
/// <summary>
/// Interaction logic for Topbar.xaml
/// </summary>
public partial class Topbar : UserControl {

    public Window Window {
        get { return (Window)GetValue(WindowProperty); }
        set {
            SetValue(WindowProperty, value);
        }
    }

    public static readonly DependencyProperty WindowProperty =
        DependencyProperty.Register("Window", typeof(Window), typeof(Topbar), new PropertyMetadata(null, WindowChangedCallback));

    private static void WindowChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        if(d is Topbar topbar) {
            topbar.SetCommands();
        }
    }

    public Topbar() {
        InitializeComponent();
    }

    private ICommand MinimizeCommand {
        get { return (ICommand)GetValue(MinimizeCommandProperty); }
        set { SetValue(MinimizeCommandProperty, value); }
    }

    private ICommand ResizeCommand {
        get { return (ICommand)GetValue(ResizeCommandProperty); }
        set { SetValue(ResizeCommandProperty, value); }
    }

    private ICommand CloseCommand {
        get { return (ICommand)GetValue(CloseCommandProperty); }
        set { SetValue(CloseCommandProperty, value); }
    }

    private static readonly DependencyProperty MinimizeCommandProperty =
        DependencyProperty.Register("MinimizeCommand", typeof(ICommand), typeof(Topbar), new PropertyMetadata(null));

    private static readonly DependencyProperty ResizeCommandProperty =
        DependencyProperty.Register("ResizeCommand", typeof(ICommand), typeof(Topbar), new PropertyMetadata(null));

    private static readonly DependencyProperty CloseCommandProperty =
        DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(Topbar), new PropertyMetadata(null));

    [MemberNotNull(nameof(ResizeCommand), nameof(MinimizeCommand), nameof(CloseCommand))]
    private void SetCommands() {
        ResizeCommand = new ResizeCommand(Window);
        MinimizeCommand = new MinimizeCommand(Window);
        CloseCommand = new CloseCommand(Window);
    }

}
