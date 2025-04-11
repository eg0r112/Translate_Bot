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
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace BotOKE
{
    public class BotMethods
    {
        private IWebDriver driver;
        private static readonly HttpClient client = new HttpClient();
        private static readonly string token = "8137282106:AAHdkipByKbtyVGjk-UhwFkb0ZFHD4bR9fw"; //токен моего бота
        private static readonly ITelegramBotClient botClient = new TelegramBotClient(token); //объявляю бота

        [OneTimeSetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); // Включение безголового режима
            options.AddArgument("--no-sandbox"); // Опционально, для устранения проблем с безопасностью
            options.AddArgument("--disable-dev-shm-usage"); // Опционально, для устранения проблем с памятью

            driver = new ChromeDriver(options);
            GetTextFromElementByXPathWithoutWait();
        }

        public static string elementText, elementText1, ln;

        [Test]
        public void GetTextFromElementByXPathWithoutWait()
        {
            // Открываем нужный URL
            driver.Navigate().GoToUrl($"https://translate.google.com/?hl=ru&sl=ru&tl={sooo}&text={soo}&op=translate"); // Замените на нужный URL

            // XPath для элемента, текст которого нужно получить
            string xpath = "//*[@id=\"yDmH0d\"]/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz/div[1]/div[6]/div/div[1]/span[1]/span/span"; // Замените на нужный XPath

            try
            {
                // Прямое получение элемента без ожидания
                var element = driver.FindElement(By.XPath(xpath));

                // Получение текста из элемента
                elementText = element.Text;
                Console.WriteLine(elementText);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Элемент не найден.");
                TearDown();
                Setup();
            }
            TearDown();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        public void Chek()
        {
            // botClient.OnCallbackQuery += Bot_OnCallbackQuery;
            botClient.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync); //добавляет обработчик событий *изменения* *ошибки*
        }
        public static string user, soo, sooo, so, txtSoo, so1;
        public static long IdUs;
        public static int schet2, schet1, schet3, che, ch3,ch1,ch2, oi;
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
    if(massange.Text == "Автор")
    {   schet2=0;
        schet1=0;
        schet3=0;
        che = 0;
        oi = 0;
     await botClient.SendTextMessageAsync(IdUs, $"Телеграм: t.me/Marix929");
    };
    if(massange.Text == "/stop")
    {
        schet2=0;
        schet1=0;
        schet3=0;
        che = 0;
        oi = 0;
        await botClient.SendTextMessageAsync(IdUs, $"Остановлено");
    }
    if(schet2==1 & massange.Text != "Перевод с Нейросетью")
    {
    foreach(var key in Franch.Keys)
    {
        if(key == massange.Text)
        {
            object[] values = Franch[key];
            await botClient.SendTextMessageAsync(IdUs, $"Английский: {values[0]} \nФранцузский: {values[1]}");
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
        che = 0;
        oi = 0;
        await botClient.SendTextMessageAsync(IdUs, $"Введите /stop чтобы выключить переводчик \nВведите слово для перевода");
    }
    if(schet1==1 & massange.Text != "Перевод с Нейросетью")
    {
    foreach(var key in Angl.Keys)
    {
        if(key == massange.Text)
        {
            await botClient.SendTextMessageAsync(IdUs, $"Английский: {Angl[key]}");
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
        che = 0;
        oi = 0;
        await botClient.SendTextMessageAsync(IdUs, $"Введите /stop чтобы выключить переводчик \nВведите слово для перевода");
    }
    if(massange.Text == "/lang")
    {
        await botClient.SendTextMessageAsync(IdUs,"Выберите один или несколько \nНапример: \nГрузинский Японский \nили \nКитайский");
        che = -2;
    }
    if(schet3 == 1 & che == 0)
    {
        BotMethods bootM = new BotMethods();
        string[] words = massange.Text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        
        // Проверка количества слов
        if (words.Length == 1)
        {
            soo = massange.Text.Replace(" ", "");
        }
        else if (words.Length > 1)
        {
            soo = massange.Text.Replace(" ", "%20");
        }
        if(oi == 1)
        {
            string[] wordss = so.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordss)
            {
                switch (word)
            {
            case "Английский":
            sooo = "en";
            break;
            case "Французский":
            sooo = "fr";
            break;
            case "Китайский":
            sooo = "zh-TW";
            break;
            case "Немецкий":
            sooo = "de";
            break;   
            case "Испанский":
            sooo = "es";
            break;   
            case "Японский":
            sooo = "ja";
            break;   
            case "Грузинский":
            sooo = "ka";
            break;   
            case "Шотландский":
            sooo = "gd";
            break;    
            }
            bootM.Setup();
            txtSoo = txtSoo + $"{word}: {elementText} \n";
            Console.WriteLine($"txtSoo: {txtSoo} \nword: {word} \nelementText: {elementText}");
            }
        } 
        else
        {
            bootM.Setup();
            txtSoo =$"{so}: {elementText} \n";
        }
        await botClient.SendTextMessageAsync(IdUs, txtSoo);
        elementText = null;
        elementText1 = null;
        sooo = null;
    }
    if(che == -2 || che == -1)
    {
        BotMethods bootM = new BotMethods();
        string[] words = massange.Text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        // Проверка количества слов
        if (words.Length == 1)
        {
            so = massange.Text.Replace(" ", "");
            switch (massange.Text.Replace(" ", ""))
        {
            case "Английский":
            sooo = "en";
            break;
            case "Французский":
            sooo = "fr";
            break;
            case "Китайский":
            sooo = "zh-TW";
            break;
            case "Немецкий":
            sooo = "de";
            break;   
            case "Испанский":
            sooo = "es";
            break;   
            case "Японский":
            sooo = "ja";
            break;   
            case "Грузинский":
            sooo = "ka";
            break;   
            case "Шотландский":
            sooo = "gd";
            break;    
        }
        oi = 0;
        }
        else if (words.Length > 1)
        {
            if(che==-1)
            {
            foreach (string word in words)
            {
                switch (word.Replace(" ", ""))
            {
            case "Английский":
            so = so.Replace("/lang", "") + "Английский ";
            break;
            case "Французский":
            so = so.Replace("/lang", "") + "Французский ";
            break;
            case "Китайский":
            so = so.Replace("/lang", "") + "Китайский ";
            break;
            case "Немецкий":
            so = so.Replace("/lang", "") + "Немецкий ";
            break;   
            case "Испанский":
            so = so.Replace("/lang", "") + "Испанский ";
            break;   
            case "Японский":
            so = so.Replace("/lang", "") + "Японский ";
            break;   
            case "Грузинский":
            so = so.Replace("/lang", "") + "Грузинский ";
            break;   
            case "Шотландский":
            so = so.Replace("/lang", "") + "Шотландский ";
            break;    
            }
            }
            }
        oi = 1;
        }
        che++;
        if(che==0)
        {
            await botClient.SendTextMessageAsync(IdUs,"Введите текст для перевода");
        }
    }
    if(massange.Text == "Перевод с Нейросетью")
    {
        schet1=0;
        schet2=0;
        schet3=1;
        che = 0;
        oi = 0;
        sooo = "en";
        so = "Английский";
        await botClient.SendTextMessageAsync(IdUs, $"Введите /stop чтобы выключить переводчик \nВыберите один или несколько языков для перевода: \nАнглийский \nФранцузский \nКитайский \nНемецкий \nИспанский \nЯпонский \nГрузинский \nШотландский \nЧтобы изменить язык введите /lang \nПо умолчанию установлен Английский \nЕсли бот не отвечает - подождите");
    }
            if (update.Message.Text == "/start")
            {
                schet2=0;
                schet1=0;
                schet3=0;
                che = 0;
                oi = 0;
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