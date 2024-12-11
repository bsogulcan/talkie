using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Channel.Extensions;

public static class KeycloakAuthenticationExtensions
{
    public static WebApplicationBuilder AddKeycloakAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = bool.Parse(builder.Configuration["Authentication:RequireHttpsMetadata"]);
                o.Audience = builder.Configuration["Authentication:Audience"];
                o.MetadataAddress = builder.Configuration["Authentication:BaseUrl"] +
                                    builder.Configuration["Authentication:MetadataAddress"];
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Authentication:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Authentication:Audience"],
                    ValidateIssuerSigningKey = true
                };
            });

        return builder;
    }
}