using NUnit.Framework;

namespace Test
{
    public class Tests : TestBase
    {
        [Test]
        [Category("Smoke")]
        [Description("Generate password with default settings")]
        public void TC1()
        {
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(24, 36);
        }
    }
}
