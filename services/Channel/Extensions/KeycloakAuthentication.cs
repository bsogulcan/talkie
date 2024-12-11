using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Channel.Extensions;

public static class KeycloakAuthentication
{
    public static WebApplicationBuilder AddKeycloakAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = bool.Parse(builder.Configuration["Authentication:RequireHttpsMetadata"]);
                o.Audience = builder.Configuration["Authentication:Audience"];
                o.MetadataAddress = builder.Configuration["Authentication:MetadataAddress"];
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Authentication:ValidIssuer"],
                };
            });

        return builder;
    }
}