using Authenticator.Database;
using Authenticator.Messages;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;

namespace Authenticator.ViewModels;

public partial class AuthenticatorPageViewModel : PageViewModelBase
{
    public override string PageName { get; protected set; } = "Authenticator";

    public ObservableCollection<AuthenticatorAccountViewModel> Accounts { get; } = [];

    [RelayCommand]
    public async Task AddAccountAsync()
    {
        var account = await WeakReferenceMessenger.Default.Send(new AddAccountMessage());

        if (account is not null)
        {
            Accounts.Add(account);

            await SQLiteConnection.InsertAuthenticatorAccount(account._account);

            System.Diagnostics.Debug.WriteLine(
                $"{account.Issuer}, {account.Secret}, {account.Username}, {account.Period}, {account.Digits}, {account.Algorithm}, {account.Type}"
            );
        }
    }
}
