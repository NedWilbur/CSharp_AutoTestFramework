using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ATB;

namespace _WebFramework.Views.Home
{
    public class BaseView
    {
        Actions Actions { get; }

        public BaseView(WebDriver driver)
        {
            Actions = driver.Actions;
        }
    }
}
