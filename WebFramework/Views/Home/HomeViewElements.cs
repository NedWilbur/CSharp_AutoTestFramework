using AutoTestBase;

namespace _WebFramework.Views.Home
{
    public class HomeViewElements
    {
        public Element LinkByText(string text) => new(By.XPath, $"//li/a[contains(text(), '{text}')]");
    }
}
