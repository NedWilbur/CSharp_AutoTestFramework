using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ATB;

namespace _WebFramework.Views.Home
{
    public class HomeViewElements
    {
        public Element LinkByText(string text) => new(By.XPath, $"//li/a[contains(text(), '{text}')]");
    }
}
