using PluginArchitecture.Plugins.Interfaces;
using PluginArchitecture.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var pluginPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Plugins");
PluginLoader.LoadPlugins(builder.Services, pluginPath);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var plugins = app.Services.GetServices<IPlugin>();

foreach (var plugin in plugins)
{
    plugin.MapEndpoints(app);
}

app.Run();
