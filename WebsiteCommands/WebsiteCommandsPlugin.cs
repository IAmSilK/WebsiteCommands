using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenMod.API.Plugins;
using OpenMod.Unturned.Plugins;
using System;
using WebsiteCommands.API.Commands;
using WebsiteCommands.Commands;
using WebsiteCommands.Configuration;

[assembly: PluginMetadata("WebsiteCommands",
    DisplayName = "Website Commands",
    Author = "SilK",
    Website = "https://github.com/IAmSilK/WebsiteCommands")]

namespace WebsiteCommands
{
    public class WebsiteCommandsPlugin : OpenModUnturnedPlugin
    {
        private readonly IConfiguration _configuration;
        private readonly ICommandSourceController _commandSourceController;

        public WebsiteCommandsPlugin(
            IConfiguration configuration,
            ICommandSourceController commandSourceController,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _configuration = configuration;
            _commandSourceController = commandSourceController;
        }

        protected override async UniTask OnLoadAsync()
        {
            var commands = _configuration.GetSection("commands").Get<WebsiteCommandConfig[]?>();

            if (commands != null)
            {
                foreach (var config in commands)
                {
                    await _commandSourceController.AddCommandAsync(new WebsiteCommandRegistration(this, config));
                }

                await _commandSourceController.InvalidateAsync();
            }
        }

        protected override UniTask OnUnloadAsync()
        {
            return UniTask.CompletedTask;
        }
    }
}
