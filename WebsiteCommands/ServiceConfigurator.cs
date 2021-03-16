using Microsoft.Extensions.DependencyInjection;
using OpenMod.API.Ioc;
using OpenMod.Core.Commands;
using WebsiteCommands.Commands;

namespace WebsiteCommands
{
    public class ServiceConfigurator : IServiceConfigurator
    {
        public void ConfigureServices(IOpenModServiceConfigurationContext openModStartupContext, IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<CommandStoreOptions>(
                options => options.AddCommandSource<WebsiteCommandSource>());
        }
    }
}
