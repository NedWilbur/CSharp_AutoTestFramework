using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _WebFramework.Views.Home
{
    public class BaseView
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string HeaderText { get; set; }

        public BaseView(string name) => Name = name;
    }
}
