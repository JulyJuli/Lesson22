using Game.implementations;
using Game.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Game.classes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAbleToShuffle, ArrayShuffle>();
        }
    }
}