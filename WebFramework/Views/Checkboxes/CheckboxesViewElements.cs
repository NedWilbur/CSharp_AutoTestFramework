using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoTestBase;

namespace _WebFramework.Views.Home
{
    public class CheckboxesViewElements
    {
        public Element Checkbox1 => new(By.XPath, "//form[@id='checkboxes']/input[1]");
        public Element Checkbox2 => new(By.XPath, "//form[@id='checkboxes']/input[2]");
    }
}
