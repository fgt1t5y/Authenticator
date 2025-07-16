using Authenticator.Messages;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Messaging;

namespace Authenticator.Views;

public partial class AddAccountWindow : Window
{
    public AddAccountWindow()
    {
        InitializeComponent();

        WeakReferenceMessenger.Default.Register<AddAccountWindow, AddAccountConfirmedMessage>(
            this,
            static (w, m) => w.Close(m.NewAccount)
        );
    }
}
