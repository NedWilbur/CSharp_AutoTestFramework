using WebFramework.Views.Home;
using AutoTestBase;

namespace WebFramework.Views
{
    /// <summary>
    /// Home for all defined POMs
    /// </summary>
    public class Views
    {
        public HomeView Home { get; }

        public Views(WebDriver driver)
        {
            Home = new HomeView(driver);
        }
    }
}