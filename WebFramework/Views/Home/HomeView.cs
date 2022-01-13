using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoTestBase;

namespace _WebFramework.Views.Home
{
    public class HomeView : BaseView
    {
        private HomeViewElements Elements { get; } = new HomeViewElements();
        public HomeView(WebDriver driver) : base(driver) { }

        public void ClickLink(string link) => Actions.Click(Elements.LinkByText(link));
    }
}
