using ATB;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ATB
{
    public class WebDriver
    {
        public IWebDriver Driver { get; }
        public Config Config { get; }
        public Actions Actions { get; }

        public WebDriver(Config config)
        {
            Config = config;
            Log.Debug($"Creating '{Config.Browser}' webdriver");

            // Create Driver
            Driver = Config.Browser switch
            {
                Browser.Chrome => new ChromeDriver(Config.BrowserOptions),
                Browser.Edge => new EdgeDriver(Config.BrowserOptions),
                Browser.Firefox => new FirefoxDriver(Config.BrowserOptions),
                _ => throw new ArgumentOutOfRangeException()
            };

            // Configure Driver Settings
            Driver.Manage().Window.Size = Config.Resolution;
            Driver.Manage().Timeouts().ImplicitWait = Config.ImplicitWait;
            Driver.Manage().Timeouts().AsynchronousJavaScript = Config.AsynchronousJavaScriptTimeout;
            Driver.Manage().Timeouts().PageLoad = Config.PageLoadTimeout;

            Actions = new Actions(this);
            Driver.Navigate().GoToUrl(Config.BaseUrl);
        }
    }
}
