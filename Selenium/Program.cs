using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Selenium
{
    class Program
    {
        IWebDriver driver;


        public void createDriver()
        {
            var options = new ChromeOptions();
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"/software/chromedriver.exe");‪
            //object p = System.setProperty("webdriver.chrome.driver", "C:\\Drivers\\chromedriver.exe");
            //options.AddArgument($"--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36 KTXN {Guid.NewGuid():N}");
            options.AddArgument("start-maximized");
            options.AddArgument("disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument($"--user-agent={2323123}");
            options.AddArgument("test-type=browser");
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService("/software/"), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //visitHomepage = true;
        }
        static void main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IWebDriver driver1 = new ChromeDriver();
            driver1.Navigate().GoToUrl("https://google.com");
            
        }

        [SetUp]
        public void Initialize()
        {
            createDriver();
            driver.Navigate().GoToUrl("https://challenge.flinks.io/Authorize/794653419");
            
        }
        [Test]
        public void ExecuteTest()
        {
            var afCookie = driver.Manage().Cookies.GetCookieNamed(".AspNetCore.Antiforgery.w5W7x28NAIs");
            var sessionCookie = driver.Manage().Cookies.GetCookieNamed(".AspNetCore.Session");


            

           // await GetMmAsync();

            var username = driver.FindElement(By.XPath("//input[contains(@name, 'username')]"));
            var password = driver.FindElement(By.XPath("//input[contains(@name, 'password')]"));

            username.Clear();
            username.SendKeys("2222");

            password.Clear();
            password.SendKeys("2222");

            Thread.Sleep(1000);

            var submit = driver.FindElement(By.XPath("//button[contains(@type, 'submit')]"));
            var popoopo = submit.Text;

            submit.Click();


            //LogInbtn.Click();
            //driver1.Close();
        }

        [TearDown]
        public void CleanUp()
        {
            //driver.Close();
        }
    }
}
