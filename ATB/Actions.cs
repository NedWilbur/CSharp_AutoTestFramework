using OpenQA.Selenium;

namespace AutoTestBase
{

    public class Actions
    {
        internal IWebDriver Driver { get; }
        public WaitFor WaitFor { get; }

        public Actions(WebDriver webDriver)
        {
            Driver = webDriver.Driver;
            WaitFor = new WaitFor(this);
        }

        private List<IWebElement> FindElements(Element element, bool throwException = true)
        {
            var elements = element.By switch
            {
                // Selenium & Appium Web
                By.Id => Driver.FindElements(OpenQA.Selenium.By.Id(element.Path)),
                By.CssSelector => Driver.FindElements(OpenQA.Selenium.By.CssSelector(element.Path)),
                By.ClassName => Driver.FindElements(OpenQA.Selenium.By.ClassName(element.Path)),
                By.XPath => Driver.FindElements(OpenQA.Selenium.By.XPath(element.Path)),
                _ => throw new NotImplementedException(),
            };

            if (elements.Count == 0 && throwException) Log.Error($"Element not found: {element}");

            return elements.ToList();
        }
        private IWebElement FindElement(Element element) => FindElements(element).First();

        // TODO: Move to own class with overloads such as Sleep.Seconds(int x), Sleep.Ms...
        public void Sleep(int ms)
        {
            Log.Info($"Sleeping for {ms}");
            Task.Delay(ms).Wait();
        }

        public void Click(Element element)
        {
            Log.Info($"Clicking {element}");
            FindElement(element).Click();
        }

        public void Type(Element element, string text)
        {
            Log.Info($"Typing '{text}' in {element}");
            FindElement(element).SendKeys(text);
        }

        public bool Exist(Element element, bool throwException = false)
        {
            Log.Info($"Checking if element exist: {element}");
            return FindElements(element).Any();
        }

        public string GetText(Element element)
        {
            Log.Info($"Getting text of: {element}");
            return FindElement(element).Text;
        }

        public string GetAttribute(Element element, string attribute)
        {
            Log.Info($"Getting attribute value '{attribute}' of: {element}");
            return FindElement(element).GetAttribute(attribute);
        }

        public bool IsSelected(Element element)
        {
            Log.Info($"Getting if element is selected: {element}");
            return FindElement(element).Selected;
        }

        // Browser Actions (TODO: Add more actions & move to own sub class - Actions.Browser.*)
        public void Quit()
        {
            Log.Info("Quiting browser");
            Driver?.Quit();
        }
    }
}
