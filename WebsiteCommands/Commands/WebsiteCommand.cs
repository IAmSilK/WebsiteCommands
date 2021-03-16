using Cysharp.Threading.Tasks;
using OpenMod.Core.Ioc;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Users;
using System;

namespace WebsiteCommands.Commands
{
    [DontAutoRegister]
    public class WebsiteCommand : UnturnedCommand
    {
        private readonly WebsiteCommandData _commandData;

        public WebsiteCommand(WebsiteCommandData commandData, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _commandData = commandData;
        }

        protected override async UniTask OnExecuteAsync()
        {
            var user = (UnturnedUser) Context.Actor;

            await UniTask.SwitchToMainThread();

            user.Player.Player.sendBrowserRequest(_commandData.Message, _commandData.Url);
        }
    }
}
