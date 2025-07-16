using ReactiveUI;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;

namespace Authenticator.ViewModels;

public enum Algorithm
{
	SHA1,
	SHA256,
	SHA512,
	GOST3411_2012_256,
	GOST3411_2012_512
}

public partial class AddAccountWindowViewModel : ViewModelBase
{
	private string _Issuer = string.Empty;

	private string _Secret = string.Empty;

	private bool _ShowAdvancedOptions = false;

	private string _Username = string.Empty;

	private string _Period = "30";

	private Algorithm _SelectedAlgorithm = Algorithm.SHA1;

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

	public Algorithm SelectedAlgorithm
	{
		get => _SelectedAlgorithm;
		set => this.RaiseAndSetIfChanged(ref _SelectedAlgorithm, value);
	}

	[RelayCommand]
	public void CancleAddAccount()
	{
		WeakReferenceMessenger.Default.Send(new Messages.AddAccountCancledMessage());
	}
}
