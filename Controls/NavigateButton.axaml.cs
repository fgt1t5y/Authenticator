using Avalonia.Controls.Metadata;
using Avalonia.Controls;
using Avalonia;

namespace Authenticator.Controls;

[PseudoClasses(":active")]
public class NavigateButton : Button
{
    public static readonly StyledProperty<bool> IsActiveProperty =
      AvaloniaProperty.Register<NavigateButton, bool>(nameof(IsActive));

    public bool IsActive
    {
        get => GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        PseudoClasses.Set(":active", IsActive);
    }
}
