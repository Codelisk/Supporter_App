using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Uno.Presentation.Auth;
using Supporter_Uno.Presentation.Chats;
using Supporter_Uno.Presentation.Folders;
using Supporter_Uno.Presentation.Folders.Add;
using Supporter_Uno.Presentation.Topics;
using Supporter_Uno.Presentation.Topics.Add;

namespace Supporter_Uno;

internal static class Routes
{
    internal static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        views.Register(
            new ViewMap(ViewModel: typeof(ShellViewModel)),
            new ViewMap<MainPage, MainViewModel>(),
            new ViewMap<LoginPage, LoginPageViewModel>(),
            new ViewMap<FolderOverviewPage, FolderOverviewPageViewModel>(),
            new ViewMap<AddFolderPage, AddFolderPageViewModel>(),
            new ViewMap<TopicOverviewPage, TopicOverviewPageViewModel>(),
            new ViewMap<AddTopicPage, AddTopicPageViewModel>(),
            new ViewMap<ChatPage, ChatPageViewModel>()
        );

        routes.Register(
            new RouteMap(
                "",
                View: views.FindByViewModel<ShellViewModel>(),
                Nested:
                [
                    new("Main", View: views.FindByView<MainPage>(), IsDefault: true),
                    new("Login", View: views.FindByView<LoginPage>()),
                    new("Folders", View: views.FindByView<FolderOverviewPage>()),
                    new("AddFolder", View: views.FindByView<AddFolderPage>()),
                    new("Topics", View: views.FindByView<TopicOverviewPage>()),
                    new("AddTopic", View: views.FindByView<AddTopicPage>()),
                    new("Chat", View: views.FindByView<ChatPage>()),
                ]
            )
        );
    }
}
