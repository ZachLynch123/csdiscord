using System;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace csdiscord
{
    class Program
    {
        private DiscordSocketClient Client;
        private CommandService Commands;
        static void Main(string[] args)
            => new Program().AsyncTasks().GetAwaiter().GetResult();
        
        private async Task AsyncTasks()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            Commands = new CommandService(new CommandServiceConfig
            
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            Client.MessageReceived += Client_MessageRecieved;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);

            Client.Ready += Client_Ready;
            Client.Log += Client_Log;

            await Client.LoginAsync(TokenType.Bot, "MzkxMjUxNDQyODU5NTA3NzEy.Dyo5Gg.tpgOKLHQyX9e06UQ5G-q4zYg-rs");
            await Client.StartAsync();

            await Task.Delay(-1);

        }

        private async Task Client_Log(LogMessage Message)
        {
            Console.WriteLine($"{DateTime.Now} at {Message.Source} {Message.Message}");
        }

        private async Task Client_Ready()
        {
            await Client.SetGameAsync("Testing...");
        }
        private async Task Client_MessageRecieved(SocketMessage arg)
        {

            // configure commands
            throw new NotImplementedException();
        }
    }
}
