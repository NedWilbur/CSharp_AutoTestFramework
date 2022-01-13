using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Drawing;

namespace AutoTestBase
{
    public enum Browser { Chrome, Firefox, Edge }

    public class Config
    {
        public dynamic BrowserOptions { get; set; }

        // Browser
        public string BaseUrl { get; set; } = "http://the-internet.herokuapp.com/";
        public Browser Browser { get; set; } = Browser.Chrome;
        public Size Resolution { get; set; } = new(1920, 1080);
        public TimeSpan ImplicitWait { get; set; } = TimeSpan.FromSeconds(30);
        public TimeSpan PageLoadTimeout { get; set; } = TimeSpan.FromMinutes(1);
        public TimeSpan AsynchronousJavaScriptTimeout { get; set; } = TimeSpan.FromSeconds(30);

        public Config(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    BrowserOptions = new ChromeOptions();
                    return;
                case Browser.Edge:
                    BrowserOptions = new EdgeOptions();
                    return;
                case Browser.Firefox:
                    BrowserOptions = new FirefoxOptions();
                    return;
                default:
                    Log.Warn("Unknown browser, using Chrome");
                    BrowserOptions = new ChromeOptions();
                    return;
            }
        }

        // TODO: Validate config
        // TODO: Output config
    }
}