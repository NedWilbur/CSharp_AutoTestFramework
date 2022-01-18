using NUnit.Framework;
using WebFramework.Views.Home;

namespace Test
{
    public class Tests : Base
    {
        [Test]
        [Category("Smoke")]
        [Description("Generate password with default settings")]
        public void TC1()
        {
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(24, 36);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `APPLEID` preset")]
        public void TC2()
        {
            View.Home.ClickPreset(Preset.APPLEID);
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(25, 31);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `APPLEID` preset")]
        public void TC3()
        {
            View.Home.ClickPreset(Preset.APPLEID);
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(25, 31);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `APPLEID` preset")]
        public void TC4()
        {
            View.Home.ClickPreset(Preset.APPLEID);
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(25, 31);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `APPLEID` preset")]
        public void TC5()
        {
            View.Home.ClickPreset(Preset.APPLEID);
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(25, 31);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `APPLEID` preset")]
        public void TC6()
        {
            View.Home.ClickPreset(Preset.APPLEID);
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(25, 31);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `APPLEID` preset")]
        public void TC7()
        {
            View.Home.ClickPreset(Preset.APPLEID);
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(25, 31);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `APPLEID` preset")]
        public void TC8()
        {
            View.Home.ClickPreset(Preset.APPLEID);
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(25, 31);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `APPLEID` preset")]
        public void TC9()
        {
            View.Home.ClickPreset(Preset.APPLEID);
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(25, 31);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `APPLEID` preset")]
        public void TC10()
        {
            View.Home.ClickPreset(Preset.APPLEID);
            View.Home.ClickGeneratePassword();
            View.Home.Validate.GeneratedPasswordsLength(25, 31);
        }
    }
}
