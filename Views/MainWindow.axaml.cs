using Authenticator.Messages;
using Authenticator.ViewModels;
using Authenticator.Models;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Messaging;

namespace Authenticator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (Design.IsDesignMode)
        {
            return;
        }

        WeakReferenceMessenger.Default.Register<MainWindow, AddAccountMessage>(this, static (w, m) =>
        {
            var dialog = new AddAccountWindow
            {
                DataContext = new AddAccountWindowViewModel()
            };

            m.Reply(dialog.ShowDialog<AuthenticatorAccountViewModel?>(w));
        });
    }
}
