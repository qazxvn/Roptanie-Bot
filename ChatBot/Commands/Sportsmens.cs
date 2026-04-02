using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBot.Commands;

public class Sportsmens : IBotCommand
{
    public string CommandName => "/спортики";

    public async Task ExecuteCommandAsync(ITelegramBotClient botClient, Message msg, CancellationToken ct)
    {
        if (msg.ReplyToMessage is { } reply)
        {
            var user = reply.From?.FirstName;
            var senderName = msg.From?.Username != null ? $"@{msg.From.Username}" : "Аноним";

            await botClient.SendMessage(msg.Chat.Id, $"{senderName} отправил спортиков на {user}", cancellationToken: ct);
        }
    }
}