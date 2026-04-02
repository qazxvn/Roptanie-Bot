using ChatBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBot.Commands;

public class ShowRoptanieBalance : IBotCommand
{
    public string CommandName => "/роптания";

    public async Task ExecuteCommandAsync(ITelegramBotClient botClient, Message msg, CancellationToken ct)
    {
        var roptania = UsersRoptanie.ShowBalance(msg.From?.Id);

        await botClient.SendMessage(msg.Chat.Id, $"У {msg.From?.Username} {roptania} роптаний", cancellationToken: ct);
    }
}