using Microsoft.OpenApi.Models;

namespace Channel.Api.Extensions;

public static class SwaggerGenExtensions
{
    public static void AddSwaggerGen(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talkie - Channel Service", Version = "v1" });
            c.AddSecurityDefinition("keycloak", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(builder.Configuration["Authentication:BaseUrl"] + builder.Configuration["Authentication:AuthorizationUrl"]),
                        Scopes = new Dictionary<string, string>
                        {
                            { "openid", "openid" },
                            { "profile", "profile" }
                        }
                    }
                }
            });


            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "keycloak"
                        },
                        In = ParameterLocation.Header,
                        Name = "Bearer",
                        Scheme = "Bearer",
                    },
                    []
                }
            });
        });
    }

    public static WebApplication UseSwaggerUIWithOAuthClientId(this WebApplication app)
    {
        app.UseSwaggerUI(options =>
        {
            options.OAuthClientId(app.Configuration["Authentication:ClientId"]);
            options.OAuthUsePkce();
        });

        return app;
    }
}