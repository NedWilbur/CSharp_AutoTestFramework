using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _WebFramework.Views.Home
{
    public class HomeView : BaseView
    {
        private HomeViewElements Elements { get; }
        public HomeView() : base("Home")
        {
            Elements = new HomeViewElements();
        }

        //public void ClickLink(string link) => 
    }
}
