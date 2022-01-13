using AutoTestBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Log.Debug(e.ToString());
                }
                finally
                {
                    Actions.Sleep(500);
                }
            }

            Log.Error($"FAILED: {logMessage}");
            return false;
        }

        public bool AttributeEqual(Element element, string attribute, string value) => _AttributeEqual(element, attribute, value, false);
        public bool AttributeNotEqual(Element element, string attribute, string value) => _AttributeEqual(element, attribute, value, true);
        private bool _AttributeEqual(Element element, string attribute, string value, bool reverse)
        {
            string logMessage = reverse
                ? $"Waiting for {element} attribute {attribute} to NOT equal {value}"
                : $"Waiting for {element} attribute {attribute} to equal {value}";
            Log.Info(logMessage);

            Stopwatch stopwatch = new();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds / 1000 <= timeoutInSeconds)
            {
                try
                {
                    if (!reverse ^ Actions.GetAttribute(element, attribute).Equals(value))
                        return true;
                    else if (reverse ^ !Actions.GetAttribute(element, attribute).Equals(value))
                        return true;
                }
                catch (StaleElementReferenceException)
                {
                    Log.Warn($"StaleElementReference: {element}");
                }
                catch (Exception e)
                {
                    Log.Debug(e.ToString());
                }
                finally
                {
                    Actions.Sleep(500);
                }
            }

            Log.Error($"FAILED: {logMessage}");
            return false;
        }
    }
}
