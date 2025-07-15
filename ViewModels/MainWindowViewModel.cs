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
    get { return _CurrentPage; }
    private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
  }

  public string CurrentPageName
  {
    get { return _CurrentPageName; }
    private set { this.RaiseAndSetIfChanged(ref _CurrentPageName, value); }
  }

  public bool AtAuthenticatorPage
  {
    get { return _AtAuthenticatorPage; }
    private set { this.RaiseAndSetIfChanged(ref _AtAuthenticatorPage, value); }
  }

  public bool AtPasswordsPage
  {
    get { return _AtPasswordsPage; }
    private set { this.RaiseAndSetIfChanged(ref _AtPasswordsPage, value); }
  }

  public bool AtSettingsPage
  {
    get { return _AtSettingsPage; }
    private set { this.RaiseAndSetIfChanged(ref _AtSettingsPage, value); }
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
