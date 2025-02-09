namespace Supporter_Uno.Presentation;

public partial class ShellViewModel
{
    private readonly INavigator _navigator;

    public ShellViewModel(INavigator navigator)
    {
        _navigator = navigator;
        // Add code here to initialize or attach event handlers to singleton services
    }
}
