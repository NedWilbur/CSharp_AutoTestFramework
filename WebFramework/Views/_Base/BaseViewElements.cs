using AutoTestBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _WebFramework.Views
{
    public class BaseViewElements
    {
        public Element Header = new(By.CssSelector, "h3");
    }
}
