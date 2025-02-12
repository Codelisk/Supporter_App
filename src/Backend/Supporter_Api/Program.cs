using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(
        options =>
        {
            builder.Configuration.Bind("AzureAd", options);
            options.Authority = "https://login.microsoftonline.com/common/v2.0"; // Akzeptiert alle Tenants
            options.TokenValidationParameters.ValidIssuers = new[] // Erlaubt mehrere Issuer
            {
                "https://login.microsoftonline.com/common/v2.0",
                "https://login.microsoftonline.com/{tenant_id}/v2.0", // Falls ein bestimmter Tenant weiterhin erlaubt sein soll
            };
        },
        options =>
        {
            builder.Configuration.Bind("AzureAd", options);
            options.Authority = "https://login.microsoftonline.com/common/v2.0"; // Akzeptiert alle Tenants
            options.TokenValidationParameters.ValidIssuers = new[] // Erlaubt mehrere Issuer
            {
                "https://login.microsoftonline.com/common/v2.0",
                "https://login.microsoftonline.com/{tenant_id}/v2.0", // Falls ein bestimmter Tenant weiterhin erlaubt sein soll
            };
        }
    )
    .EnableTokenAcquisitionToCallDownstreamApi(options => { })
    .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
    .AddInMemoryTokenCaches();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
