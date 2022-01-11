using _ATB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _WebFramework
{
    public static class Util
    {
        // Driver Config
        private static ATB.Config Config = new(ATB.Browser.Chrome)
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
