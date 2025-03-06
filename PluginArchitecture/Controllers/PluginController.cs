using Microsoft.AspNetCore.Mvc;
using PluginArchitecture.Plugins.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PluginArchitecture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PluginController : ControllerBase
    {
        private readonly IEnumerable<IPlugin> _plugins;

        public PluginController(IEnumerable<IPlugin> plugins)
        {
            _plugins = plugins;
        }

        [HttpGet("plugins")]
        public ActionResult<IEnumerable<string>> GetPlugins()
        {
            var pluginNames = _plugins.Select(p => p.GetName()).ToList();
            Console.WriteLine($"Loaded plugins: {string.Join(", ", pluginNames)}");
            return Ok(pluginNames);
        }
    }
}