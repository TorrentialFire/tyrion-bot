using System;
using DSharpPlus.CommandsNext;

namespace Tyrion.Services
{
    public static class ServiceProviderSetup
    {
        public static DependencyCollection BuildProvider() =>
            new DependencyCollectionBuilder()
            .AddInstance(Tyrion.DiscordClient)
            // TODO(wilsontfwi): Add services that the command modules need access to here!
            .Add<GoTQuoteAPI>()
            // ...
            .Build();
    }
}