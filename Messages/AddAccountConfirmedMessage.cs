using Authenticator.ViewModels;

namespace Authenticator.Messages;

public class AddAccountConfirmedMessage(AuthenticatorAccountViewModel newAccount)
{
    public AuthenticatorAccountViewModel NewAccount { get; } = newAccount;
}
