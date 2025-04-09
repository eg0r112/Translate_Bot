using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using System.Diagnostics;
using Serilog;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
namespace BotOKE
{
    public class BotMethods
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string token = "7551179520:AAH7QmPYn1rfsdObRm0mpqgdvDohh-qxJAc"; //токен моего бота
        private static readonly ITelegramBotClient botClient = new TelegramBotClient(token); //объявляю бота
        public void Chek()
        {
            // botClient.OnCallbackQuery += Bot_OnCallbackQuery;
            botClient.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync); //добавляет обработчик событий *изменения* *ошибки*
        }
        public static string user;
        public static long IdUs;
        public static int schet2, schet1, schet3, ch3,ch1,ch2;
        private static async Task HandleUpdateAsync(ITelegramBotClient Botclient, Update update, CancellationToken token)
        {
            Dictionary<string, string> Angl = new Dictionary<string, string>
        {
            { "стол", "table" },
            { "привет", "Hello" },
            { "мир", "world" },
            { "игра", "game" },
            { "Россия", "Russia" },
            { "улица", "street" },
            { "парк", "park" },
            { "глаз", "eye" },
            { "бегать", "run" },
            { "видеть", "see" }
        };
        Dictionary<string, object[]> Franch = new Dictionary<string, object[]>
        {
            { "кот", new object[] {"cat","chat"}},
            { "собака", new object[] {"dog","chien"}},
            { "день", new object[] {"day","jour"}},
            { "семь", new object[] {"seven","sept"}},
            { "прекрасно", new object[] {"wonderful","merveilleux"}},
            { "говорить", new object[] {"speak","parler"}},
            { "стул", new object[] {"chair","chaise"}},
            { "страна", new object[] {"country","pays"}},
            { "поле", new object[] {"field","champ"}},
            { "круг", new object[] {"circle","cercle"}}
        };
            var massange = update.Message;       //получаю соо из бота
            user = massange.From.FirstName;      //ник челика
            IdUs = massange.Chat.Id;
                    // if(update.CallbackQuery.Data=="Angl")
                    // {
                    //     await botClient.SendTextMessageAsync(IdUs, "Англ");
                    // }
    //        await botClient.SendTextMessageAsync(massange.Chat.Id,
    // "Кнопки удалены.",
    // replyMarkup: new ReplyKeyboardRemove());
    if(massange.Text == "Автор")
    {   schet2=0;
        schet1=0;
        schet3=0;
     await botClient.SendTextMessageAsync(IdUs, $"Телеграм: t.me/Marix929");
    };
    if(massange.Text == "/stop")
    {
        schet2=0;
        schet1=0;
        schet3=0;
    }
    if(schet2==1)
    {
    foreach(var key in Franch.Keys)
    {
        if(key == massange.Text)
        {
            object[] values = Franch[key];
            await botClient.SendTextMessageAsync(IdUs, $"Английский:{values[0]} \nФранцузский:{values[1]}");
            ch2=1;
        }
    }
    if(ch2==0)
    {
        await botClient.SendTextMessageAsync(IdUs, "Я не понял");
    } else
    {
        ch2=0;
    }
    }
    if(massange.Text == "Перевод на Французский")
    {
        schet2=1;
        schet1=0;
        schet3=0;
        await botClient.SendTextMessageAsync(IdUs, $"Введите /stop чтобы выключить переводчик");
    }
    if(schet1==1)
    {
    foreach(var key in Angl.Keys)
    {
        if(key == massange.Text)
        {
            await botClient.SendTextMessageAsync(IdUs, $"Английский:{Angl[key]}");
            ch1=1;
        }
    }
    if(ch1==0)
    {
        await botClient.SendTextMessageAsync(IdUs, "Я не понял");
    } else
    {
        ch1=0;
    }
    }
    if(massange.Text == "Перевод на Английский")
    {
        schet1=1;
        schet2=0;
        schet3=0;
        await botClient.SendTextMessageAsync(IdUs, $"Введите /stop чтобы выключить переводчик");
    }
    if(schet3 == 1)
    {
        
    }
    if(massange.Text == "Перевод с Нейросетью")
    {
        schet1=0;
        schet2=0;
        schet3=1;
        await botClient.SendTextMessageAsync(IdUs, $"Введите /stop чтобы выключить переводчик");
    }
            if (update.Message.Text == "/start")
            {
        schet2=0;
        schet1=0;
        schet3=0;
                var keyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new KeyboardButton[] { "Перевод на Английский", "Перевод на Французский"},
                        new KeyboardButton[] { "Перевод с Нейросетью" },
                        new KeyboardButton[] { "Автор" } // Кнопка в меню
                    })
                    {
                        ResizeKeyboard = true // Автоматически подстраивает размер клавиатуры
                    };

                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat,
                        text: $"Привет, {user}! Этот бот позволяет переводить сообщения",
                        replyMarkup: keyboard
                    );
            }
        }
        private static async Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"Произошла ошибка: {exception.Message}");
            await botClient.SendTextMessageAsync(IdUs, "Произошла непредвиденная ошибка!");
        }
    }
}