using AutoTestBase;

namespace _WebFramework.Views.Home
{
    public class BaseView
    {
        protected Actions Actions { get; }

        public BaseView(WebDriver driver)
        {
            Actions = driver.Actions;
        }
    }
}
