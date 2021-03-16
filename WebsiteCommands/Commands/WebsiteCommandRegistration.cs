using OpenMod.API;
using OpenMod.API.Commands;
using OpenMod.API.Permissions;
using OpenMod.API.Prioritization;
using OpenMod.Core.Ioc;
using OpenMod.Unturned.Users;
using System;
using System.Collections.Generic;
using WebsiteCommands.Configuration;

namespace WebsiteCommands.Commands
{
    public class WebsiteCommandRegistration : ICommandRegistration
    {
        private readonly WebsiteCommandData _commandData;

        public WebsiteCommandRegistration(IOpenModComponent component, WebsiteCommandConfig config)
        {
            Component = component;

            Id = $"{component.OpenModComponentId}.{config.CommandName}";
            Name = config.CommandName;
            Description = config.Description;
            Priority = Priority.High;

            _commandData = new WebsiteCommandData
            {
                Message = config.Message,
                Url = config.Url
            };

            IsEnabled = true;

            Aliases = null;
            PermissionRegistrations = null;
            Syntax = null;
            ParentId = null;
        }

        public IOpenModComponent Component { get; }

        public string Id { get; }

        public string Name { get; }

        public IReadOnlyCollection<string>? Aliases { get; }

        public IReadOnlyCollection<IPermissionRegistration>? PermissionRegistrations { get; }

        public string? Description { get; }

        public string? Syntax { get; }

        public Priority Priority { get; }

        public string? ParentId { get; }

        public bool IsEnabled { get; }

        public ICommand Instantiate(IServiceProvider serviceProvider)
        {
            return ActivatorUtilitiesEx.CreateInstance<WebsiteCommand>(Component.LifetimeScope, _commandData);
        }

        public bool SupportsActor(ICommandActor actor)
        {
            return actor is UnturnedUser;
        }
    }
}
