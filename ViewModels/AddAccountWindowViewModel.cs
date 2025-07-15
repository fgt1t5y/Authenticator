using ReactiveUI;

namespace Authenticator.ViewModels;

public partial class AddAccountWindowViewModel : ViewModelBase
{
  public AddAccountWindowViewModel()
  {
    this.Issuer = string.Empty;
    this.Secret = string.Empty;
  }

  private string _Issuer = string.Empty;

  private string _Secret = string.Empty;

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
}
