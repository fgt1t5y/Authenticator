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
        await WeakReferenceMessenger.Default.Send(new AddAccountMessage());
    }
}
