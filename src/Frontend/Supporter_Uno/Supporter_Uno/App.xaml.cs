using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using Supporter_AI;
using Supporter_Dtos;
using Supporter_Uno.ApiClient.Helpers;
using Supporter_Uno.Presentation.Auth;
using Supporter_Uno.Presentation.Chats;
using Supporter_Uno.Presentation.Folders;
using Supporter_Uno.Presentation.Topics;
using Supporter_Uno.Providers;
using Uno.Extensions.Http;
using Uno.Resizetizer;

namespace Supporter_Uno;

public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    protected Window? MainWindow { get; private set; }
    protected IHost? Host { get; private set; }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args);

        // Add navigation support for toolkit controls such as TabBar and NavigationView
        builder
            .UseToolkitNavigation()
            .Configure(
                (host, window) =>
                    host
#if DEBUG
                    // Switch to Development environment when running in DEBUG
                    .UseEnvironment(Environments.Development)
#endif
                    .UseLogging(
                            configure: (context, logBuilder) =>
                            {
                                // Configure log levels for different categories of logging
                                logBuilder
                                    .SetMinimumLevel(
                                        context.HostingEnvironment.IsDevelopment()
                                            ? LogLevel.Information
                                            : LogLevel.Warning
                                    )
                                    // Default filters for core Uno Platform namespaces
                                    .CoreLogLevel(LogLevel.Warning);

                                // Uno Platform namespace filter groups
                                // Uncomment individual methods to see more detailed logging
                                //// Generic Xaml events
                                //logBuilder.XamlLogLevel(LogLevel.Debug);
                                //// Layout specific messages
                                //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
                                //// Storage messages
                                //logBuilder.StorageLogLevel(LogLevel.Debug);
                                //// Binding related messages
                                //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
                                //// Binder memory references tracking
                                //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
                                //// DevServer and HotReload related
                                //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
                                //// Debug JS interop
                                //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);
                            },
                            enableUnoLogging: true
                        )
                        .UseConfiguration(configure: configBuilder =>
                            configBuilder.EmbeddedSource<App>()
                        )
                        // Enable localization (see appsettings.json for supported languages)
                        .UseLocalization()
                        // Register Json serializers (ISerializer and ISerializer)
                        .UseSerialization(
                            (context, services) =>
                                services
                                    .AddContentSerializer(context)
                                    .AddJsonTypeInfo(
                                        WeatherForecastContext.Default.IImmutableListWeatherForecast
                                    )
                        )
                        .UseHttp(
                            (context, services) =>
                            {
                                var endpointOptions = new EndpointOptions
                                {
                                    Url = context.Configuration.GetSection("ApiClient")["Url"],
                                };

                                services
                                    // Register HttpClient
                                    //TODO ADD#if DEBUG
                                    // DelegatingHandler will be automatically injected into Refit Client
                                    .AddTransient<DelegatingHandler, DebugHttpHandler>()
                                    //TODO ADD#endif
                                    .AddSingleton<IWeatherCache, WeatherCache>()
                                    .AddRefitClient<IAIFolderApi>(
                                        context,
                                        endpointOptions,
                                        settingsBuilder: ConfigureRefitSettings
                                    )
                                    .AddRefitClient<IAITopicApi>(
                                        context,
                                        endpointOptions,
                                        settingsBuilder: ConfigureRefitSettings
                                    )
                                    .AddRefitClient<IAzureTopicMappingApi>(
                                        context,
                                        endpointOptions,
                                        settingsBuilder: ConfigureRefitSettings
                                    )
                                    .AddRefitClient<IChatQuestionApi>(
                                        context,
                                        endpointOptions,
                                        settingsBuilder: ConfigureRefitSettings
                                    )
                                    .AddRefitClient<IChatAnswerApi>(
                                        context,
                                        endpointOptions,
                                        settingsBuilder: ConfigureRefitSettings
                                    )
                                    .AddRefitClient<ITrainingMessageApi>(
                                        context,
                                        endpointOptions,
                                        settingsBuilder: ConfigureRefitSettings
                                    );
                            }
                        )
                        .UseAuthentication(auth =>
                        {
                            auth.AddMsal(window);
                            auth.AddCustom(
                                configure =>
                                {
                                    configure.Login(
                                        async (
                                            sp,
                                            dispatcher,
                                            tokenCache,
                                            credentials,
                                            cancellationToken
                                        ) =>
                                        {
                                            return default;
                                        }
                                    );
                                },
                                "ApiKey"
                            );
                        })
                        .ConfigureServices(
                            (context, services) =>
                            {
                                // TODO: Register your services
                                //services.AddSingleton<IMyService, MyService>();
                                services.TryAddScoped<BaseVmServices>();
                                services.AddAIServices(context.Configuration);
                            }
                        )
                        .UseNavigation(Routes.RegisterRoutes)
            );
        MainWindow = builder.Window;

#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

        Host = await builder.NavigateAsync<Shell>(
            initialNavigate: async (services, navigator) =>
            {
#if BROWSERWASM
                await navigator.NavigateViewAsync<OrderlyzeDirectLoginPage>(
                    this,
                    qualifier: Qualifiers.Nested
                );
                return;
#endif
                var auth = services.GetRequiredService<IAuthenticationService>();
                var token = await services.GetRequiredService<ITokenCache>().AccessTokenAsync();
                //var authenticated = await auth.RefreshAsync();
                //tokens = await services
                //    .GetRequiredService<ITokenCache>()
                //    .AccessTokenAsync(CancellationToken.None);
#if WINDOWS

                if (
                    !await AzureServiceChecker.CheckServiceAvailability(
                        services.GetRequiredService<IConfiguration>().GetSection("ApiClient")["Url"]
                    )
                )
                {
                    await navigator.ShowMessageDialogAsync(this, content: "Server nicht verfügbar");
                }
#endif

                if (await auth.IsAuthenticated())
                {
                    await navigator.NavigateViewAsync<FolderOverviewPage>(
                        this,
                        qualifier: Qualifiers.Nested
                    );
                }
                else
                {
                    await navigator.NavigateViewAsync<LoginPage>(
                        this,
                        qualifier: Qualifiers.Nested
                    );
                }
            }
        );
    }

    private static void ConfigureRefitSettings(IServiceProvider x, RefitSettings y)
    {
        y.ContentSerializer = new SystemTextJsonContentSerializer(
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
    }
}
