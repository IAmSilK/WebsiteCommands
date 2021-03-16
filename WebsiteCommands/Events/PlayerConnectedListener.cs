using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Players.Connections.Events;
using System.Threading.Tasks;

namespace WebsiteCommands.Events
{
    public class PlayerConnectedListener : IEventListener<UnturnedPlayerConnectedEvent>
    {
        private readonly IConfiguration _configuration;

        public PlayerConnectedListener(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("join");
        }

        public Task HandleEventAsync(object? sender, UnturnedPlayerConnectedEvent @event)
        {
            var enabled = _configuration.GetValue("enabled", false);

            if (enabled)
            {
                var url = _configuration.GetValue("url", "");
                var message = _configuration.GetValue("message", "");
                var delay = _configuration.GetValue("delay", 3f);

                async UniTask OnPlayerConnected()
                {
                    await UniTask.SwitchToMainThread();

                    await UniTask.Delay((int)(delay * 1000));

                    @event.Player.Player.sendBrowserRequest(message, url);
                }

                OnPlayerConnected().Forget();
            }

            return Task.CompletedTask;
        }
    }
}
