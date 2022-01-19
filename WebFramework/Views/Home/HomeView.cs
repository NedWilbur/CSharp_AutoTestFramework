using AutoTestBase;
using NUnit.Framework;
using WebFramework.Views.Base;
using WebFramwork.Objects;

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

        /// <summary>
        /// Click given preset configuration button
        /// </summary>
        /// <param name="preset"></param>
        public void ClickPreset(Preset preset) => Actions.Click(Elements.Presets.ButtonByText(preset));

        /// <summary>
        /// Click button to generate new password(s)
        /// </summary>
        public void ClickGeneratePassword() 
        {
            Actions.Click(Elements.Generate.GeneratePasswordButton);
            Actions.WaitFor.AttributeNotLength(Elements.Generate.GeneratedPasswordsTextarea, "value", 0);
        }

        /// <summary>
        /// Expand given setting container
        /// </summary>
        /// <param name="setting">Setting container to collapse</param>
        public void ExpandSettingContainer(Setting setting)
        {
            Log.Info($"Expanding '{setting}' container");
            switch (setting)
            {
                case Setting.WORDS:
                    Actions.Click(Elements.Settings.Words.ExpandButton);
                    break;
                case Setting.TRANSFORMATIONS:
                    Actions.Click(Elements.Settings.Transformations.ExpandButton);
                    break;
                case Setting.SEPARATOR:
                    Actions.Click(Elements.Settings.Separator.ExpandButton);
                    break;
                case Setting.PADDING_DIGITS:
                    Actions.Click(Elements.Settings.PaddingDigits.ExpandButton);
                    break;
                case Setting.PADDING_SYMBOLS:
                    Actions.Click(Elements.Settings.PaddingSymbols.ExpandButton);
                    break;
                case Setting.LOADSAVE_CONFIG:
                    Actions.Click(Elements.Settings.LoadSave.ExpandButton);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            Actions.Sleep(250); // wait for animation
            return;
        }

        /// <summary>
        /// Expand all settings containers
        /// </summary>
        public void ExpandAllSettingContainers() {
            foreach (Setting setting in Enum.GetValues(typeof(Setting)))
                ExpandSettingContainer(setting);
        }

        /// <summary>
        /// Collapse provided setting container
        /// </summary>
        /// <param name="setting">Setting container to collapse</param>
        public void CollpaseSettingContainer(Setting setting)
        {
            Log.Info($"Expanding '{setting}' container");
            switch (setting)
            {
                case Setting.WORDS:
                    Actions.Click(Elements.Settings.Words.CollapseButton);
                    break;
                case Setting.TRANSFORMATIONS:
                    Actions.Click(Elements.Settings.Transformations.CollapseButton);
                    break;
                case Setting.SEPARATOR:
                    Actions.Click(Elements.Settings.Separator.CollapseButton);
                    break;
                case Setting.PADDING_DIGITS:
                    Actions.Click(Elements.Settings.PaddingDigits.CollapseButton);
                    break;
                case Setting.PADDING_SYMBOLS:
                    Actions.Click(Elements.Settings.PaddingSymbols.CollapseButton);
                    break;
                case Setting.LOADSAVE_CONFIG:
                    Actions.Click(Elements.Settings.LoadSave.CollapseButton);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            Actions.Sleep(250); // wait for animation
            return;
        }

        /// <summary>
        /// Collapse all setting containers
        /// </summary>
        public void CollapseAllSettingContainers()
        {
            foreach (Setting setting in Enum.GetValues(typeof(Setting)))
                CollpaseSettingContainer(setting);
        }

        public void ClickSaveConfigButton() => Actions.Click(Elements.Settings.LoadSave.SaveConfigButton);
        public void ClickLoadConfigButton() => Actions.Click(Elements.Settings.LoadSave.LoadConfigButton);

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

            /// <summary>
            /// Gets the list of generated passwords
            /// </summary>
            /// <returns></returns>
            private List<string> GetPasswords() => Actions.GetAttribute(Elements.Generate.GeneratedPasswordsTextarea, "value").Split('\n').ToList();

            /// <summary>
            /// Validate each generated passwords is within the given min/max range
            /// </summary>
            /// <param name="min">Minimum password length</param>
            /// <param name="max">Maximum password length</param>
            public void GeneratedPasswordsLength(int min, int max) =>
                GetPasswords().ForEach(password => Assert.IsTrue(password.Length >= min && password.Length <= max,
                    $"Generated password length is NOT between {min} and {max}"));

            /// <summary>
            /// Validate each generated passwords is within the given min/max range
            /// </summary>
            public void GeneratedPasswordsLength(WebFramwork.Objects.Config config) => GeneratedPasswordsLength(config.Summary.MinLength, config.Summary.MaxLength);

            /// <summary>
            /// Validate generated password contains given text
            /// </summary>
            /// <param name="text">Text to validate is within password(s)</param>
            public void GeneratedPasswordContains(string text) => Assert.Contains(text, GetPasswords(), "Generated passwords does not contain text");

            /// <summary>
            /// Validate UI settings equals given config
            /// </summary>
            public void Settings(WebFramwork.Objects.Config config)
            {
                // TODO: Break out into individual methods for more usability. This method would simply call all other methods.
                Assert.AreEqual(config.Words.Description, Actions.GetText(Elements.Settings.Words.Summary));
                Assert.AreEqual(config.Transformations.Description, Actions.GetText(Elements.Settings.Transformations.Summary));
                Assert.AreEqual(config.Seperator.Description, Actions.GetText(Elements.Settings.Separator.Summary));
                Assert.AreEqual(config.PaddingDigits.Description, Actions.GetText(Elements.Settings.PaddingDigits.Summary));
                // TODO: Validate all fields for each settings section. Currently only does a few fields for demo purposes.
            }

            public void GeneratedConfigEquals(string text) => Assert.AreEqual(text, Actions.GetAttribute(Elements.Settings.LoadSave.ConfigField, "value").Replace("\r\n", string.Empty));
        }
    }
}