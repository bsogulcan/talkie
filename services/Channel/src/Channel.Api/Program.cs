using Channel.Api.Extensions;
using Channel.Application;
using Channel.Domain.Channels;
using Channel.Infrastructure;
using Channel.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.AddKeycloakAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("Default"));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
builder.Services.AddScoped<IChannelRepository, ChannelRepository>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUIWithOAuthClientId();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();