using Authenticator.Messages;
using Authenticator.ViewModels;
using Authenticator.Database;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Messaging;

namespace Authenticator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        SQLiteConnection.InitializeDatabase();

        // SQLiteConnection.InitializeTables();

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

    private void MainWindow_Closing()
    {
        SQLiteConnection.DestroyConnection();
    }
}
