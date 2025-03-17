using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.ExternalConnectors;
using Microsoft.Identity.Web;
using Supporter_Api;
using Supporter_Api.Auth;
using Supporter_Api.Helpers.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKey", null)
    .AddMicrosoftIdentityWebApi(builder.Configuration)
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
    .AddInMemoryTokenCaches();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        "AzureADUsers",
        policy => policy.RequireAuthenticatedUser().AddAuthenticationSchemes("Bearer")
    );

    options.AddPolicy(
        "ApiKeyUsers",
        policy => policy.RequireAuthenticatedUser().AddAuthenticationSchemes("ApiKey")
    );
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowSpecificOrigin",
        policy =>
        {
            policy
                .WithOrigins(
                    "https://orderlyzesupporterapp-dqfzbhfsewdhcnam.canadacentral-01.azurewebsites.net",
                    "https://localhost:5001",
                    "https://localhost:7209/"
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});
builder.Services.AddControllers();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Prod"))
);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

new ModuleInitializer().Configure(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
