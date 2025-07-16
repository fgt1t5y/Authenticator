namespace Authenticator.Models;

public class AuthenticatorAccount(string issue, string secret)
{
    public string Issuer { get; set; } = issue;

    public string Secret { get; set; } = secret;
}
