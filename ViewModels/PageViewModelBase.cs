namespace Authenticator.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
  public abstract string PageName { get; protected set; }
}
