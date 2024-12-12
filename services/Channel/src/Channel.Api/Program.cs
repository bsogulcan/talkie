using Channel.Api.Extensions;
using Channel.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.AddKeycloakAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("Default"));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUIWithOAuthClientId();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();