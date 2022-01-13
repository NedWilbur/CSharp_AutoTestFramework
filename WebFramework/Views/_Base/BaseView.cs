using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
