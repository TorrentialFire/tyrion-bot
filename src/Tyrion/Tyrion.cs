using System;
using System.Net.Http;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Tyrion.Services;
using Tyrion.Commands;

namespace Tyrion
{
    class Tyrion
    {
        public static readonly HttpClient HttpClient = new HttpClient();

        public static readonly Random Random = new Random();
        public static readonly DiscordClient DiscordClient = new DiscordClient(new DiscordConfiguration
        {
            Token = Environment.GetEnvironmentVariable("TYRION_TOKEN"),
            TokenType = TokenType.Bot,
            UseInternalLogHandler = true,
            LogLevel = LogLevel.Debug
        });

        public static readonly CommandsNextModule Commands = DiscordClient.UseCommandsNext(new CommandsNextConfiguration
        {
            StringPrefix = "!",
            Dependencies = ServiceProviderSetup.BuildProvider()
        });
        
        static async Task Main()
        {
            Commands.RegisterCommands<GoTCommands>();
            
            await DiscordClient.ConnectAsync();

            await Task.Delay(-1);
        }
    }
}
