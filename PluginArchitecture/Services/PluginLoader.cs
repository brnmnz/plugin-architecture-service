using PluginArchitecture.Plugins.Interfaces;
using System.Reflection;

namespace PluginArchitecture.Services
{
    public class PluginLoader
    {
        public static void LoadPlugins(IServiceCollection services, string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Directory not found: {path}");
                return;
            }

            var pluginAssemblies = Directory.GetFiles(path, "*.dll")
                                            .Select(Assembly.LoadFrom)
                                            .ToList();

            foreach (var assembly in pluginAssemblies)
            {
                Console.WriteLine($"Loaded assembly: {assembly.FullName}");
            }

            var pluginTypes = pluginAssemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface)
                .ToList();

            foreach (var type in pluginTypes)
            {
                Console.WriteLine($"Registering plugin: {type.FullName}");
                services.AddTransient(typeof(IPlugin), type);
            }
        }
    }
}