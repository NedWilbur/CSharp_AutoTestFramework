using AutoTestBase;

namespace WebFramework.Views.Home
{
    public enum Preset { APPLEID, DEFAULT, NTLM, SECURITYQ, WEB16, WEB32, WIFI, XKCD }

    public class HomeViewElements
    {
        public Element LinkByText(string text) => new(By.XPath, $"//li/a[contains(text(), '{text}')]");
        public _PresetsContainer Presets = new();
        public class _PresetsContainer
        {
            public Element Self => new(By.Id, "preset_buttons_container");
            public Element ButtonByText(Preset preset) => new(By.CssSelector, $"#{Self.Path} input[type='button'][value='{preset}']");
            public Element APPLEIDButton => ButtonByText(Preset.APPLEID);
            public Element DEFAULTButton => ButtonByText(Preset.DEFAULT);
            public Element NTLMButton => ButtonByText(Preset.NTLM);
            public Element SECURITYQButton => ButtonByText(Preset.SECURITYQ);
            public Element WEB16Button => ButtonByText(Preset.WEB16);
            public Element WEB32Button => ButtonByText(Preset.WEB32);
            public Element WIFIButton => ButtonByText(Preset.WIFI);
            public Element XKCDButton => ButtonByText(Preset.XKCD);
        }

        public _SettingsContainer Settings = new();
        public class _SettingsContainer
        {
            public _Words Words = new();
            public class _Words
            {
                public Element ExpandButton => new(By.CssSelector, "#section_words_icon[alt='Expand Section']");
                public Element CollapseButton => new(By.CssSelector, "#section_words_icon[alt='Collapse Section']");
                public Element Summary => new(By.Id, "section_words_summary");

                public Element DictionarySelect => new(By.Id, "dict");
                public Element WordCountSelect => new(By.Id, "num_words");
                public Element MinWordCountSelect => new(By.Id, "word_length_min");
                public Element MaxWordCountSelect => new(By.Id, "word_length_max");
            }

            public _Transformations Transformations = new();
            public class _Transformations
            {
                public Element ExpandButton => new(By.CssSelector, "#section_transformations_icon[alt='Expand Section']");
                public Element CollapseButton => new(By.CssSelector, "#section_transformations_icon[alt='Collapse Section']");
                public Element Summary => new(By.Id, "section_transformations_summary");

                // TODO: define rest of elements
            }

            public _Separator Separator = new();
            public class _Separator
            {
                public Element ExpandButton => new(By.CssSelector, "#section_separator_icon[alt='Expand Section']");
                public Element CollapseButton => new(By.CssSelector, "#section_separator_icon[alt='Collapse Section']");
                public Element Summary => new(By.Id, "section_separator_summary");

                // TODO: define rest of elements
            }

            public _PaddingDigits PaddingDigits = new();
            public class _PaddingDigits
            {
                public Element ExpandButton => new(By.CssSelector, "#section_padding_digits_icon[alt='Expand Section']");
                public Element CollapseButton => new(By.CssSelector, "#section_padding_digits_icon[alt='Collapse Section']");
                public Element Summary => new(By.Id, "section_padding_digits_summary");

                // TODO: define rest of elements
            }

            public _PaddingSymbols PaddingSymbols = new();
            public class _PaddingSymbols
            {
                public Element ExpandButton => new(By.CssSelector, "#section_padding_symbols_icon[alt='Expand Section']");
                public Element CollapseButton => new(By.CssSelector, "#section_padding_symbols_icon[alt='Collapse Section']");
                public Element Summary => new(By.Id, "section_padding_symbols_summary");


                // TODO: define rest of elements
            }

            public _LoadSave LoadSave = new();
            public class _LoadSave
            {
                public Element ExpandButton => new(By.CssSelector, "#section_load_save_icon[alt='Expand Section']");
                public Element CollapseButton => new(By.CssSelector, "#section_load_save_icon[alt='Collapse Section']");

                // TODO: define rest of elements
            }
        }

        public _GenerateContainer Generate = new();
        public class _GenerateContainer
        {
            public Element GeneratePasswordButton => new(By.Id, "generate_password_btn");
            public Element NumPasswordSelect => new(By.Id, "num_passwords");
            public Element GeneratedPasswordsTextarea => new(By.Id, "generated_password");
        }
    }
}
