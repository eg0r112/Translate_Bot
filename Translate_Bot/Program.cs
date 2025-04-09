using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.Diagnostics;
using BotOKE;
// using Bot;
class Program
{
    private static readonly string token = "7551179520:AAH7QmPYn1rfsdObRm0mpqgdvDohh-qxJAc"; //токен моего бота
    private static readonly ITelegramBotClient botClient = new TelegramBotClient(token); //объявляю бота

    static async Task Main(string[] args)
    {
        var me = await botClient.GetMeAsync(); 
        Console.WriteLine($"Название бота: {me.FirstName}  \nUsername бота: {me.Username}");
        BotMethods botMethods = new BotMethods();
        // Programm pr = new Programm();
        // pr.Maiii();
        botMethods.Chek();
        Console.ReadLine();
    }
}
