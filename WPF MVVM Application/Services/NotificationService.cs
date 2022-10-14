using System;

namespace WPF_MVVM_Application.Services;

/// <summary>
/// Provides methods to communicate to the user using a built-in message view.
/// </summary>
public class NotificationService : INotificationService {

    public event Action<string>? NewMessage;

    private void OnNewMessage(string message) {
        NewMessage?.Invoke(message);
    }

    public void Send(string message) {
        OnNewMessage(new(message));
    }

    public void Send(string message, string title) {
        OnNewMessage($"{title}:{Environment.NewLine}{message}");
    }
}