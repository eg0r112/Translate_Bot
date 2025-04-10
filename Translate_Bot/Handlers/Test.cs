using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class ImmediateXPathTextRetrievalTests
    {
        private IWebDriver driver;

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

        [Test]
        public void GetTextFromElementByXPathWithoutWait()
        {
            // Открываем нужный URL
            driver.Navigate().GoToUrl("https://translate.google.com/?hl=ru&sl=ru&tl=en&text=как%20дела&op=translate"); // Замените на нужный URL

            // XPath для элемента, текст которого нужно получить
            string xpath = "//*[@id=\"yDmH0d\"]/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz/div[1]/div[6]/div/div[1]/span[1]/span/span"; // Замените на нужный XPath

            try
            {
                // Прямое получение элемента без ожидания
                var element = driver.FindElement(By.XPath(xpath));

                // Получение текста из элемента
                string elementText = element.Text;

                // Вывод текста в консоль
                Console.WriteLine(elementText);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Элемент не найден.");
            }
            TearDown();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}