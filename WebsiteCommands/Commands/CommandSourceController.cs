using Microsoft.Extensions.DependencyInjection;
using OpenMod.API.Commands;
using OpenMod.API.Ioc;
using OpenMod.API.Prioritization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsiteCommands.API.Commands;

namespace WebsiteCommands.Commands
{
    [ServiceImplementation(Lifetime = ServiceLifetime.Singleton, Priority = Priority.Lowest)]
    public class CommandSourceController : ICommandSourceController
    {
        private readonly Lazy<ICommandStore> _commandStore;
        private readonly List<ICommandRegistration> _registrations;

        public CommandSourceController(Lazy<ICommandStore> commandStore)
        {
            _commandStore = commandStore;

            _registrations = new List<ICommandRegistration>();
        }

        public Task<IReadOnlyCollection<ICommandRegistration>> GetCommandsAsync() =>
            Task.FromResult((IReadOnlyCollection<ICommandRegistration>) _registrations);

        public Task AddCommandAsync(ICommandRegistration registration)
        {
            _registrations.Add(registration);

            return Task.CompletedTask;
        }

        public Task InvalidateAsync() => _commandStore.Value.InvalidateAsync();
    }
}
