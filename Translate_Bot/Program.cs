using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.Diagnostics;
using BotOKE;

class Program
{
    private static readonly string token = "7947210961:AAHGuvXIKzS3GX6F780x4ONzoYQUpQhEYrE"; //токен моего бота
    private static readonly ITelegramBotClient botClient = new TelegramBotClient(token); //объявляю бота

    static async Task Main(string[] args)
    {
        var me = await botClient.GetMeAsync(); 
        Console.WriteLine($"Название бота: {me.FirstName}  \nUsername бота: {me.Username}");
        BotMethods botMethods = new BotMethods();
        botMethods.Chek();
        Console.ReadLine();
    }
}
