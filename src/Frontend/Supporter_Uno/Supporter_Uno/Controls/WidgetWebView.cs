using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdig;

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
        Loaded += async (_, __) =>
        {
#if !BROWSERWASM
            await this.EnsureCoreWebView2Async();
#endif

            string markdown = "# Hallo Welt\nDas ist **fetter** Text!";
            string html = Markdown.ToHtml(markdown);
            SetContent(html);
        };
    }

    public async void SetContent(string content)
    {
        content = Markdown.ToHtml(content);
#if BROWSERWASM
        this.SetHtmlAttribute("srcdoc", content);
#else
        this.NavigateToString(content);
#endif
    }
}
