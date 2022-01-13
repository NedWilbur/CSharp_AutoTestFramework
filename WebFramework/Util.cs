using AutoTestBase;
using System.Drawing;

namespace _WebFramework
{
    public static class Util
    {
        // Driver Config
        private static AutoTestBase.Config Config = new(AutoTestBase.Browser.Chrome)
        {
            BaseUrl = "http://the-internet.herokuapp.com/",
            Resolution = new Size(1920, 1080),
        };

        public static Tuple<WebDriver, Views.Views> NewBrowser()
        {
            WebDriver driver = new WebDriver(Config);
            Views.Views view = new(driver);
            return Tuple.Create(driver, view);
        }
    }
}
