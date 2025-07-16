using Authenticator.Models;

namespace Authenticator.ViewModels;

public partial class AuthenticatorAccountViewModel : ViewModelBase
{
    private readonly AuthenticatorAccount _account;

    public AuthenticatorAccountViewModel(AuthenticatorAccount account)
    {
        _account = account;
    }

    public string Issuer => _account.Issuer;

    public string Secret => _account.Secret;

    public string Username => _account.Username;

    public int Period => _account.Period;

    public OTPDigits Digits => _account.Digit;

    public OTPAlgorithms Algorithm => _account.Algorithm;

    public OTPTypes Type => _account.Type;
}
