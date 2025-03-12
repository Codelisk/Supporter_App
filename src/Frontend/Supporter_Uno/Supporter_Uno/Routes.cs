using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Uno.Presentation.Auth;
using Supporter_Uno.Presentation.Chats;
using Supporter_Uno.Presentation.Chats.Settings;
using Supporter_Uno.Presentation.Chats.Training;
using Supporter_Uno.Presentation.CodeAnalysis.Add;
using Supporter_Uno.Presentation.CodeAnalysis.Analyze;
using Supporter_Uno.Presentation.CodeAnalysis.Chat;
using Supporter_Uno.Presentation.CodeAnalysis.Overview;
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
            new ViewMap<OrderlyzeDirectLoginPage, OrderlyzeDirectLoginPageViewModel>(),
            new ViewMap<LoginPage, LoginPageViewModel>(),
            new ViewMap<FolderOverviewPage, FolderOverviewPageViewModel>(),
            new ViewMap<AddFolderPage, AddFolderPageViewModel>(),
            new ViewMap<TopicOverviewPage, TopicOverviewPageViewModel>(),
            new ViewMap<AddTopicPage, AddTopicPageViewModel>(),
            new ViewMap<ChatPage, ChatPageViewModel>(),
            new ViewMap<ChatSettingsPage, ChatSettingsPageViewModel>(),
            new ViewMap<ChatTrainingPage, ChatTrainingPageViewModel>(),
            new ViewMap<RepoOverviewPage, RepoOverviewPageViewModel>(),
            new ViewMap<RepoAddPage, RepoAddPageViewModel>(),
            new ViewMap<RepoChatPage, RepoChatPageViewModel>(),
            new ViewMap<RepoAnalyzePage, RepoAnalyzePageViewModel>(),
            new ViewMap<FileRepoAnalyzePage, FileRepoAnalyzePageViewModel>()
        );

        routes.Register(
            new RouteMap(
                "",
                View: views.FindByViewModel<ShellViewModel>(),
                Nested:
                [
                    new("Main", View: views.FindByView<MainPage>()),
                    new("Login", View: views.FindByView<LoginPage>(), IsDefault: true),
                    new("Folders", View: views.FindByView<FolderOverviewPage>()),
                    new("OrderlyzeDirectLogin", View: views.FindByView<OrderlyzeDirectLoginPage>()),
                    new("AddFolder", View: views.FindByView<AddFolderPage>()),
                    new("Topics", View: views.FindByView<TopicOverviewPage>()),
                    new("AddTopic", View: views.FindByView<AddTopicPage>()),
                    new("Chat", View: views.FindByView<ChatPage>()),
                    new("ChatSettings", View: views.FindByView<ChatSettingsPage>()),
                    new("ChatTraining", View: views.FindByView<ChatTrainingPage>()),
                    new("AddRepo", View: views.FindByView<RepoAddPage>()),
                    new("RepoOverview", View: views.FindByView<RepoOverviewPage>()),
                    new("RepoChat", View: views.FindByView<RepoChatPage>()),
                    new("RepoAnalyze", View: views.FindByView<RepoAnalyzePage>()),
                    new("FileRepoAnalyze", View: views.FindByView<FileRepoAnalyzePage>()),
                ]
            )
        );
    }
}
