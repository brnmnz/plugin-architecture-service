namespace PluginArchitecture.Plugins.Interfaces
{
    public interface IPlugin
    {
        string GetName(); 
        void MapEndpoints(IEndpointRouteBuilder endpoints);
    }
}