using System;

namespace WPF_MVVM_Application.Services;

/// <summary>
/// Represents a notification service. Used to send messages to the user.
/// </summary>
public interface INotificationService {

    /// <summary>
    /// Raised when a new message gets sent.
    /// </summary>
    public event Action<string>? NewMessage;

    /// <summary>
    /// Sends a message to the user.
    /// </summary>
    /// <param name="message"></param>
    void Send(string message);

    /// <summary>
    /// Sends a message to the user, with a selected title.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="title"></param>
    void Send(string message, string title);

}
