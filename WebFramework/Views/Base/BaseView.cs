using AutoTestBase;

namespace WebFramework.Views.Base
{
    public class BaseView
    {
        protected Actions Actions { get; }

        public BaseView(WebDriver driver)
        {
            Actions = driver.Actions;
        }

        // Methods inherited by all POMs
        public void ExampleMethod() => throw new NotImplementedException();
    }
}
