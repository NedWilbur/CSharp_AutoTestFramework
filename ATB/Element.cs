using System.Runtime.CompilerServices;


namespace AutoTestBase
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
