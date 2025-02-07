namespace Supporter_Uno.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        await MyWebView.EnsureCoreWebView2Async();
        MyWebView.NavigateToString("<html><body><p>Hello world!</p></body></html>");
    }
}
