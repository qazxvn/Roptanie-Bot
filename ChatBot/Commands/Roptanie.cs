using ChatBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBot.Commands;

public class Roptanie : IBotCommand
{
    public string CommandName => "/роптать";

    public async Task ExecuteCommandAsync(ITelegramBotClient botClient, Message msg, CancellationToken ct)
    {
        UsersRoptanie.AddToDict(msg.From?.Id);

        await botClient.SendMessage(msg.Chat.Id, $"{msg.From?.Username} +1 роптание", cancellationToken: ct);
    }
}