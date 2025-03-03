using System;
using System.Windows.Input;
using Markdig;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Supporter_Uno.Controls;

#if BROWSERWASM
[Uno.UI.Runtime.WebAssembly.HtmlElement("iframe")]
public partial class WidgetWebView : Control
#else
public partial class WidgetWebView : WebView2
#endif
{
    public WidgetWebView()
    {
        Loaded += async (_, __) => {
#if !BROWSERWASM
            await this.EnsureCoreWebView2Async();
#endif
        };
    }

    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content),
        typeof(string),
        typeof(WidgetWebView),
        new PropertyMetadata(string.Empty, OnContentChanged)
    );

    public string Content
    {
        get => (string)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is WidgetWebView webView && e.NewValue is string newContent)
        {
            webView.SetContent(newContent);
        }
    }

    public async void SetContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            return;
        content = Markdown.ToHtml(content);
#if BROWSERWASM
        this.SetHtmlAttribute("srcdoc", content);
#else
        this.NavigateToString(content);
#endif
    }
}
