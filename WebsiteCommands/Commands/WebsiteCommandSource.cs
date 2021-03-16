using OpenMod.API.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsiteCommands.API.Commands;

namespace WebsiteCommands.Commands
{
    public class WebsiteCommandSource : ICommandSource
    {
        private readonly ICommandSourceController _commandSourceController;

        public WebsiteCommandSource(ICommandSourceController commandSourceController)
        {
            _commandSourceController = commandSourceController;
        }

        public Task<IReadOnlyCollection<ICommandRegistration>> GetCommandsAsync() =>
            _commandSourceController.GetCommandsAsync();
    }
}
