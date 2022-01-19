using NUnit.Framework;
using WebFramework.Views.Home;
using WebFramwork.Objects;

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
            Config config = PresetConfig.AppleId;

            View.Home.ClickPreset(config.Preset);
            View.Home.ExpandAllSettingContainers();
            View.Home.ClickGeneratePassword();

            View.Home.Validate.Settings(config);
            View.Home.Validate.GeneratedPasswordsLength(config);
        }

        [Test]
        [Category("Smoke")]
        [Description("Password generation with `XKCD` preset")]
        public void TC3()
        {
            Config config = PresetConfig.XKCD;

            View.Home.ClickPreset(config.Preset);
            View.Home.ExpandAllSettingContainers();
            View.Home.ClickGeneratePassword();

            View.Home.Validate.Settings(config);
            View.Home.Validate.GeneratedPasswordsLength(config);
        }

        // Repeat for the rest of the presets

        [Test]
        [Category("Smoke")]
        [Description("'Save Config' generates proper JSON of settings")]
        public void TC11()
        {
            // TODO: Find better location and way of storing this messy string. Used: http://easyonlineconverter.com/converters/dot-net-string-escape.html
            string expectedConfig = "{ \"num_words\": 3, \"word_length_min\": 4, \"word_length_max\": 8, \"case_transform\": \"ALTERNATE\", \"separator_character\": \"RANDOM\", \"separator_alphabet\": [  \"!\",  \"@\",  \"$\",  \"%\",  \"^\",  \"&\",  \"*\",  \"-\",  \"_\",  \"+\",  \"=\",  \":\",  \"|\",  \"~\",  \"?\",  \"/\",  \".\",  \";\" ], \"padding_digits_before\": 2, \"padding_digits_after\": 2, \"padding_type\": \"FIXED\", \"padding_character\": \"RANDOM\", \"symbol_alphabet\": [  \"!\",  \"@\",  \"$\",  \"%\",  \"^\",  \"&\",  \"*\",  \"-\",  \"_\",  \"+\",  \"=\",  \":\",  \"|\",  \"~\",  \"?\",  \"/\",  \".\",  \";\" ], \"padding_characters_before\": 2, \"padding_characters_after\": 2, \"random_increment\": \"AUTO\"}";
            
            View.Home.ExpandSettingContainer(Setting.LOADSAVE_CONFIG);
            View.Home.ClickSaveConfigButton();

            View.Home.Validate.GeneratedConfigEquals(expectedConfig);
        }
    }
}
