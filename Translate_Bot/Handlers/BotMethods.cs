using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using System.Diagnostics;
namespace BotOKE
{
    public class BotMethods
    {
        private static readonly string token = "7947210961:AAHGuvXIKzS3GX6F780x4ONzoYQUpQhEYrE"; //токен моего бота
        private static readonly ITelegramBotClient botClient = new TelegramBotClient(token); //объявляю бота
        public void Chek()
        {
            botClient.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync); //добавляет обработчик событий *изменения* *ошибки*
        }
        public static string user;
        public static long IdUs;
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
    {   await botClient.SendTextMessageAsync(IdUs, $"Телеграм: t.me/Marix929 \nВк");
    };
            if (update.Message.Text == "/start")
            {
                var keyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new KeyboardButton[] { "Перевод на Английский", "Перевод на Французский"},
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
            // Console.WriteLine($"Произошла ошибка: {exception.Message}");
            // await botClient.SendTextMessageAsync(IdUs, "Произошла непредвиденная ошибка!");
        }
    }
}