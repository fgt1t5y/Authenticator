using Authenticator.Models;
using Authenticator.Messages;
using ReactiveUI;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using System.Text.RegularExpressions;

namespace Authenticator.ViewModels;

public enum OTPAlgorithms
{
	SHA1,
	SHA256,
	SHA512,
	GOST3411_2012_256,
	GOST3411_2012_512
}

public enum OTPDigits
{
	D6,
	D8
}

public enum OTPTypes
{
	TOPT,
	HOPT,
	HEX,
	HHEX
}

public partial class AddAccountWindowViewModel : ViewModelBase
{
	[GeneratedRegex(@"^[a-z2-7]+=*$", RegexOptions.IgnoreCase)]
	private static partial Regex Base32Regex();

	[GeneratedRegex(@"^[0-9a-f]+$", RegexOptions.IgnoreCase)]
	private static partial Regex HexRegex();

	private string _Issuer = string.Empty;

	private string _Secret = string.Empty;

	private bool _ShowAdvancedOptions = false;

	private string _Username = string.Empty;

	private string _Period = "30";

	private OTPDigits _Digits = OTPDigits.D6;

	private OTPAlgorithms _Algorithm = OTPAlgorithms.SHA1;

	private OTPTypes _Type = OTPTypes.TOPT;

	private string _ErrorMessage = string.Empty;

	public string Issuer
	{
		get => _Issuer;
		set => this.RaiseAndSetIfChanged(ref _Issuer, value);
	}

	public string Secret
	{
		get => _Secret;
		set => this.RaiseAndSetIfChanged(ref _Secret, value);
	}

	public bool ShowAdvancedOptions
	{
		get => _ShowAdvancedOptions;
		set => this.RaiseAndSetIfChanged(ref _ShowAdvancedOptions, value);
	}

	public string Username
	{
		get => _Username;
		set => this.RaiseAndSetIfChanged(ref _Username, value);
	}

	public string Period
	{
		get => _Period;
		set => this.RaiseAndSetIfChanged(ref _Period, value);
	}

	public OTPDigits Digit
	{
		get => _Digits;
		set => this.RaiseAndSetIfChanged(ref _Digits, value);
	}

	public OTPAlgorithms Algorithm
	{
		get => _Algorithm;
		set => this.RaiseAndSetIfChanged(ref _Algorithm, value);
	}

	public OTPTypes Type
	{
		get => _Type;
		set => this.RaiseAndSetIfChanged(ref _Type, value);
	}

	public string ErrorMessage
	{
		get => _ErrorMessage;
		set => this.RaiseAndSetIfChanged(ref _ErrorMessage, value);
	}

	[RelayCommand]
	public void ConfirmAddAccount()
	{
		if (string.IsNullOrWhiteSpace(Issuer))
		{
			ErrorMessage = "Issuer cannot be empty.";
			return;
		}

		if (string.IsNullOrWhiteSpace(Secret) || Secret.Length < 16)
		{
			ErrorMessage = "Secret must be at least 16 characters long.";
			return;
		}

		bool isBase32String = Base32Regex().IsMatch(Secret);
		bool isHexString = HexRegex().IsMatch(Secret);

		if (!isBase32String && !isHexString)
		{
			ErrorMessage = "Secret must be a valid Base32 or Hex string.";
			return;
		}

		if (string.IsNullOrWhiteSpace(Username))
		{
			Username = "Anonymous";
		}

		int finalPeriod = int.TryParse(Period, out var intPeriod) ? intPeriod : 30;
		OTPTypes finalType = Type;

		if (!isBase32String && isHexString && Type == OTPTypes.TOPT)
		{
			finalType = OTPTypes.HEX;
		}
		else if (!isBase32String && isHexString && Type == OTPTypes.HOPT)
		{
			finalType = OTPTypes.HHEX;
		}

		if (finalType == OTPTypes.HHEX || finalType == OTPTypes.HOPT)
		{
			finalPeriod = -1;
		}
		else if (finalPeriod <= 0)
		{
			finalPeriod = -1;
		}

		WeakReferenceMessenger.Default.Send(new AddAccountConfirmedMessage(
			new AuthenticatorAccountViewModel(
				new AuthenticatorAccount(
					Issuer, Secret, Username, finalPeriod, Digit, Algorithm, finalType
				)
			)
		));
	}
}
