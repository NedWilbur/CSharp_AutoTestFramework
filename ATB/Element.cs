using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace _ATB
{
    public enum By { Id, ClassName, CssSelector, XPath }

    public class Element
    {
        public By By { get; }
        public string Path { get; }
        public string Name { get; }

        public Element(By by, string path, [CallerMemberName] string name = "")
        {
            By = by;
            Path = path;
            Name = name;
        }

        public override string ToString() => $"{Name} (By.{By}: {Path})";
    }
}
