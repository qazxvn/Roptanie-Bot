using ChatBot;
using ChatBot.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;

var commandList = new List<IBotCommand>
{
    new Sportsmens(),
    new Roptanie(),
    new StartBot(),
    new ShowRoptanieBalance(),
    new Stepfathers()
};

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("", cancellationToken: cts.Token);

bot.StartReceiving(
    updateHandler: OnUpdate,
    errorHandler: OnError,
    cancellationToken: cts.Token
);

Console.WriteLine("Бот запущен. Нажмите Enter для выхода...");
Console.ReadLine();
cts.Cancel();

async Task OnError(ITelegramBotClient botClient, Exception ex, CancellationToken ct)
{
    Console.WriteLine($"Ошибка api: {ex.Message}");
}

async Task OnUpdate(ITelegramBotClient botClient, Update update, CancellationToken ct)
{
    await (update switch
    {
        { Message: { } message } => OnMessage(botClient, message, ct),
        { EditedMessage: { } editedMessage } => OnMessage(botClient, editedMessage, ct),
    });
}

async Task OnMessage(ITelegramBotClient botClient, Message msg, CancellationToken ct)
{
    if(msg.Text is not {} messageText)
        return;

    var mess = messageText.Split(' ')[0].ToLower();

    var command = commandList.FirstOrDefault(x => x.CommandName == mess);

    if (command is not null)
    {
        await command.ExecuteCommandAsync(botClient, msg, ct);
    }
}
