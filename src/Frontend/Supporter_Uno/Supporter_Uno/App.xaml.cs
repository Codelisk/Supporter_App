using System.Text.Json;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using Supporter_Dtos;
using Supporter_Uno.Presentation.Auth;
using Supporter_Uno.Presentation.Chats;
using Supporter_Uno.Presentation.Folders;
using Supporter_Uno.Presentation.Topics;
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

        var endpointOptions = new EndpointOptions
        {
            Url = "https://orderlyzesupporter-a4gyd0chgjh9aah6.canadacentral-01.azurewebsites.net",
        };

        // Add navigation support for toolkit controls such as TabBar and NavigationView
        builder
            .UseToolkitNavigation()
            .Configure(host =>
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
                        configBuilder.EmbeddedSource<App>().Section<AppConfig>()
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
                            services
                                // Register HttpClient
#if DEBUG
                                // DelegatingHandler will be automatically injected into Refit Client
                                .AddTransient<DelegatingHandler, DebugHttpHandler>()
#endif
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
                    )
                    .UseAuthentication(auth => auth.AddMsal(builder.Window))
                    .ConfigureServices(
                        (context, services) => {
                            // TODO: Register your services
                            //services.AddSingleton<IMyService, MyService>();
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
                var auth = services.GetRequiredService<IAuthenticationService>();
                var authenticated = await auth.RefreshAsync();

                if (authenticated && false)
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
