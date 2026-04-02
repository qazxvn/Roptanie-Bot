using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBot.Commands;

public class Stepfathers : IBotCommand
{
    public string CommandName => "/отчимы";

    public async Task ExecuteCommandAsync(ITelegramBotClient botClient, Message msg, CancellationToken ct)
    {
        if (msg.ReplyToMessage is { } reply)
        {
            var user = reply.From?.FirstName;

            await botClient.SendMessage(msg.Chat.Id, $"отчимы выебали {user}", cancellationToken: ct);
        }
    }
}