using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using PluginArchitecture.Plugins.Interfaces;

namespace NewPlugin
{
    public class NewPlugin : IPlugin
    {
        public string GetName()
        {
            return "New Plugin";
        }

        public void MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/newplugin/data", async context =>
            {
                var data = new NewPluginData { Id = 1, Name = "Sample DataA" };
                await context.Response.WriteAsJsonAsync(data);
            });
        }
    }

    public class NewPluginData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}