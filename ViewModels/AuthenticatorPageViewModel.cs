using Authenticator.Messages;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;

namespace Authenticator.ViewModels;

public partial class AuthenticatorPageViewModel : PageViewModelBase
{
    public override string PageName { get; protected set; } = "Authenticator";

    [RelayCommand]
    public async Task AddAccountAsync()
    {
        var account = await WeakReferenceMessenger.Default.Send(new AddAccountMessage());

        if (account is not null)
        {
            System.Diagnostics.Debug.WriteLine(
                $"{account.Issuer}, {account.Secret}, {account.Username}, {account.Period}, {account.Digits}, {account.Algorithm}, {account.Type}"
            );
        }
    }
}
