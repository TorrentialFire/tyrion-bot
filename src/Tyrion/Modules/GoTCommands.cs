using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Tyrion;
using Tyrion.Services;

namespace Tyrion.Commands
{
    [Group("got")]
    public class GoTCommands
    {
        private GoTQuoteAPI gotQuoteAPI;

        public GoTCommands(GoTQuoteAPI gotQuoteAPI)
        {
            this.gotQuoteAPI = gotQuoteAPI;
        }

        [Command("random")]
        public async Task RandomAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            GoTCharacter character = GoTCharacter.Characters[Tyrion.Random.Next(GoTCharacter.Characters.Length)];
            await GetQuoteAsync(ctx, character);
        }

        [Command("bronn")]
        public async Task BronnAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[0]);
        }
        
        [Command("brynden")]
        public async Task BryndenAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[1]);
        }                

        [Command("cersei")]
        public async Task CerseiAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[2]);
        }

        [Command("hound")]
        public async Task HoundAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[3]);
        }

        [Command("jaime")]
        public async Task JaimeAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[4]);
        }

        [Command("littlefinger")]
        public async Task LittlefingerAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[5]);
        }

        [Command("olenna")]
        public async Task OlennaAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[6]);
        }

        [Command("renly")]
        public async Task RenlyAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[7]);
        }

        [Command("tyrion")]
        public async Task TyrionAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[8]);
        }

        [Command("varys")]
        public async Task VarysAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await GetQuoteAsync(ctx, GoTCharacter.Characters[9]);
        }

        [Command("characters")]
        [Aliases("help")]
        public async Task CharactersAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            DiscordEmbedBuilder eb = new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Black)
                .WithTitle("GoT Quoteable Characters")
                .WithDescription("Call `!got <term>` for a quote from the character. Use `!got random` for a random quote.");

            foreach (GoTCharacter character in GoTCharacter.Characters)
            {
                eb.AddField($"{character.Name}", $"Term: {character.Term}", true);
            }

            await ctx.RespondAsync(null, false, eb.Build());
        }

        private async Task GetQuoteAsync(CommandContext ctx, GoTCharacter character)
        {
            JObject result = await gotQuoteAPI.Request(character.Term);
            string quote = (string)result["quote"];
            await ctx.RespondAsync($"\"{quote}\" - {character.Name}");
        }
    }
}