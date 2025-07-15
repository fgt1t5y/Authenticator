using ReactiveUI;

namespace Authenticator.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
  public MainWindowViewModel()
  {
    _CurrentPage = Pages[0];
    _CurrentPageName = Pages[0].PageName;
    _AtAuthenticatorPage = true;
    _AtPasswordsPage = false;
    _AtSettingsPage = false;
  }

  private readonly PageViewModelBase[] Pages =
  [
    new AuthenticatorPageViewModel(),
    new PasswordsPageViewModel(),
    new SettingsPageViewModel(),
  ];

  private PageViewModelBase _CurrentPage;

  private string _CurrentPageName = "Authenticator";

  private bool _AtAuthenticatorPage = false;

  private bool _AtPasswordsPage = false;

  private bool _AtSettingsPage = false;

  public PageViewModelBase CurrentPage
  {
    get => _CurrentPage;
    set => this.RaiseAndSetIfChanged(ref _CurrentPage, value);
  }

  public string CurrentPageName
  {
    get => _CurrentPageName;
    set => this.RaiseAndSetIfChanged(ref _CurrentPageName, value);
  }

  public bool AtAuthenticatorPage
  {
    get => _AtAuthenticatorPage;
    set => this.RaiseAndSetIfChanged(ref _AtAuthenticatorPage, value);
  }

  public bool AtPasswordsPage
  {
    get => _AtPasswordsPage;
    set => this.RaiseAndSetIfChanged(ref _AtPasswordsPage, value);
  }

  public bool AtSettingsPage
  {
    get => _AtSettingsPage;
    set => this.RaiseAndSetIfChanged(ref _AtSettingsPage, value);
  }

  private void UpdateAtPageState()
  {
    AtAuthenticatorPage = CurrentPageName == "Authenticator";
    AtPasswordsPage = CurrentPageName == "Passwords";
    AtSettingsPage = CurrentPageName == "Settings";
  }

  public void NavigateToAuthenticatorPage()
  {
    CurrentPage = Pages[0];
    CurrentPageName = CurrentPage.PageName;
    UpdateAtPageState();
  }

  public void NavigateToPasswordsPage()
  {
    CurrentPage = Pages[1];
    CurrentPageName = CurrentPage.PageName;
    UpdateAtPageState();
  }

  public void NavigateToSettingsPage()
  {
    CurrentPage = Pages[2];
    CurrentPageName = CurrentPage.PageName;
    UpdateAtPageState();
  }
}
