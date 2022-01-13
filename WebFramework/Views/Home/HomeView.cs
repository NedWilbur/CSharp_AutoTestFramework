using AutoTestBase;
using NUnit.Framework;
using WebFramework.Views.Base;

namespace WebFramework.Views.Home
{
    public class HomeView : BaseView
    {
        private HomeViewElements Elements { get; }
        public HomeViewValidate Validate { get; }

        public HomeView(WebDriver driver) : base(driver)
        {
            Elements = new HomeViewElements();
            Validate = new HomeViewValidate(this);
        }

        public void ClickPreset(Preset preset) => Actions.Click(Elements.PresetsContainer.ButtonByText(preset));
        public void ClickGeneratePassword() 
        {
            Actions.Click(Elements.GenerateContainer.GeneratePasswordButton);
            Actions.WaitFor.AttributeNotLength(Elements.GenerateContainer.GeneratedPasswordsTextarea, "value", 0);
        }

        // Validate (TODO: Move to own class)
        public class HomeViewValidate
        {
            private HomeViewElements Elements { get; } = new HomeViewElements();
            private Actions Actions { get; }

            public HomeViewValidate(HomeView view)
            {
                Elements = view.Elements;
                Actions = view.Actions;
            }

            private List<string> GetPasswords() => Actions.GetAttribute(Elements.GenerateContainer.GeneratedPasswordsTextarea, "value").Split('\n').ToList();

            public void GeneratedPasswordsLength(int min, int max) =>
                GetPasswords().ForEach(password => Assert.IsTrue(password.Length >= min && password.Length <= max,
                    $"Generated password length is NOT between {min} and {max}"));

            public void GeneratedPasswordContains(string text) => Assert.Contains(text, GetPasswords(), "Generated passwords does not contain text");
        }
    }
}