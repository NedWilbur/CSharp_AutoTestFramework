using OpenQA.Selenium;
using System.Diagnostics;

namespace AutoTestBase
{
    public class WaitFor
    {
        internal Actions Actions { get; }
        private int timeoutInSeconds = 15;

        public WaitFor(AutoTestBase.WebDriver driver)
        {
            Actions = driver.Actions;
        }

        // TODO: One general loop; each waitfor being a custom object
        // TODO: Add cojnfigurable/passable timeoutInSeconds - stored in config.cs
        // TODO: Move 'NOT' actions to subclass (so its WaitFor.Not.Exist)

        public bool Exist(Element element) => _Exist(element, false);
        public bool NotExist(Element element) => _Exist(element, true);
        private bool _Exist(Element element, bool reverse)
        {
            string logMessage = reverse
                ? $"Waiting for {element} to NOT exist"
                : $"Waiting for {element} to exist";
            Log.Info(logMessage);

            Stopwatch stopwatch = new();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds / 1000 <= timeoutInSeconds)
            {
                try
                {
                    if (!reverse ^ Actions.Exist(element))
                        return true;
                    else if (reverse ^ !Actions.Exist(element))
                        return true;
                }
                catch (StaleElementReferenceException)
                {
                    Log.Warn($"StaleElementReference: {element}");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
                finally
                {
                    Actions.Sleep(500);
                }
            }

            Log.Error($"FAILED {logMessage}");
            return false;
        }

        public bool AttributeEqual(Element element, string attribute, string value) => Attribute(element, attribute, value, true, false);
        public bool AttributeNotEqual(Element element, string attribute, string value) => Attribute(element, attribute, value, true, true);
        public bool AttributeContain(Element element, string attribute, string value) => Attribute(element, attribute, value, false, false);
        public bool AttributeNotContain(Element element, string attribute, string value) => Attribute(element, attribute, value, false, true);
        private bool Attribute(Element element, string attribute, string value, bool exact, bool reverse)
        {
            string logMessage;
            if (reverse && exact) logMessage = reverse
                ? $"Waiting for {element} attribute {attribute} to NOT equal {value}"
                : $"Waiting for {element} attribute {attribute} to equal {value}";
            else logMessage = reverse
                ? $"Waiting for {element} attribute {attribute} to NOT contain {value}"
                : $"Waiting for {element} attribute {attribute} to contain {value}";
            Log.Info(logMessage);

            Stopwatch stopwatch = new();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds / 1000 <= timeoutInSeconds)
            {
                try
                {
                    if (exact)
                        if (!reverse ^ Actions.GetAttribute(element, attribute).Equals(value))
                            return true;
                        else if (reverse ^ !Actions.GetAttribute(element, attribute).Equals(value))
                            return true;
                    else
                        if (!reverse ^ Actions.GetAttribute(element, attribute).Contains(value))
                            return true;
                        else if (reverse ^ !Actions.GetAttribute(element, attribute).Contains(value))
                            return true;
                }
                catch (StaleElementReferenceException)
                {
                    Log.Warn($"StaleElementReference: {element}");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
                finally
                {
                    Actions.Sleep(500);
                }
            }

            Log.Error($"FAILED {logMessage}");
            return false;
        }

        // TODO: Case insensitive version via .toLower/upper
        public bool TextEqual(Element element, string value) => Text(element, value, true, false);
        public bool TextNotEqual(Element element, string value) => Text(element, value, true, true);
        public bool TextContain(Element element, string value) => Text(element, value, false, false);
        public bool TextNotContain(Element element, string value) => Text(element, value, false, true);
        private bool Text(Element element, string value, bool exact, bool reverse)
        {
            string logMessage;
            if (reverse && exact) logMessage = reverse
                ? $"Waiting for {element} value to NOT equal {value}"
                : $"Waiting for {element} value to equal {value}";
            else logMessage = reverse
                ? $"Waiting for {element} value to NOT contain {value}"
                : $"Waiting for {element} value to contain {value}";
            Log.Info(logMessage);

            Stopwatch stopwatch = new();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds / 1000 <= timeoutInSeconds)
            {
                try
                {
                    if (exact)
                        if (!reverse ^ Actions.GetText(element).Equals(value))
                            return true;
                        else if (reverse ^ !Actions.GetText(element).Equals(value))
                            return true;
                        else
                        if (!reverse ^ Actions.GetText(element).Contains(value))
                            return true;
                        else if (reverse ^ !Actions.GetText(element).Contains(value))
                            return true;
                }
                catch (StaleElementReferenceException)
                {
                    Log.Warn($"StaleElementReference: {element}");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
                finally
                {
                    Actions.Sleep(500);
                }
            }

            Log.Error($"FAILED {logMessage}");
            return false;
        }


    }
}
