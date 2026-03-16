using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var ocelotConfiguration = new ConfigurationBuilder().AddJsonFile("ocelotconfig.json").Build();

builder.Services.AddOcelot(ocelotConfiguration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");



await app.UseOcelot();
app.Run();
