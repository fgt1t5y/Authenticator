using Authenticator.ViewModels;

namespace Authenticator.Models;

public class AuthenticatorAccount(
    string issue,
    string secret,
    string username,
    int period = 30,
    OTPDigits digit = OTPDigits.D6,
    OTPAlgorithms algorithm = OTPAlgorithms.SHA1,
    OTPTypes type = OTPTypes.TOPT
)
{
    public string Issuer { get; set; } = issue;

    public string Secret { get; set; } = secret;

    public string Username { get; set; } = username;

    public int Period { get; set; } = period; // seconds

    public OTPDigits Digit { get; set; } = digit;

    public OTPAlgorithms Algorithm { get; set; } = algorithm;

    public OTPTypes Type { get; set; } = type;
}
