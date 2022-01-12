using _WebFramework.Views.Home;
using _ATB;

namespace _WebFramework.Views
{
    /// <summary>
    /// Home for all defined POMs
    /// </summary>
    public class Views
    {
        public HomeView Home { get; }
        public CheckboxesView Checkboxes { get; }

        public Views(WebDriver driver)
        {
            Home = new HomeView(driver);
            Checkboxes = new CheckboxesView(driver);
        }
    }
}