using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.Diagnostics;
using BotOKE;
// using SeleniumTests;
class Program
{
    private static readonly string token = "8137282106:AAHdkipByKbtyVGjk-UhwFkb0ZFHD4bR9fw"; //токен моего бота
    private static readonly ITelegramBotClient botClient = new TelegramBotClient(token); //объявляю бота

    static async Task Main(string[] args)
    {
        var me = await botClient.GetMeAsync(); 
        Console.WriteLine($"Название бота: {me.FirstName}  \nUsername бота: {me.Username}");
        BotMethods botMethods = new BotMethods();
        // ImmediateXPathTextRetrievalTests pr = new ImmediateXPathTextRetrievalTests();
        // pr.Setup();
        botMethods.Chek();
        Console.ReadLine();
    }
}
