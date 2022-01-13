using AutoTestBase;

namespace WebFramework.Views.Home
{
    public enum Preset { APPLEID, DEFAULT, NTLM, SECURITYQ, WEB16, WEB32, WIFI, XKCD }

    public class HomeViewElements
    {
        public Element LinkByText(string text) => new(By.XPath, $"//li/a[contains(text(), '{text}')]");
        public _PresetsContainer PresetsContainer = new();
        public class _PresetsContainer
        {
            public Element Self => new(By.Id, "#preset_buttons_container");
            public Element ButtonByText(Preset preset) => new(By.CssSelector, $"{Self.Path} input[type='button'][value='{preset}']");
            public Element APPLEIDButton => ButtonByText(Preset.APPLEID);
            public Element DEFAULTButton => ButtonByText(Preset.DEFAULT);
            public Element NTLMButton => ButtonByText(Preset.NTLM);
            public Element SECURITYQButton => ButtonByText(Preset.SECURITYQ);
            public Element WEB16Button => ButtonByText(Preset.WEB16);
            public Element WEB32Button => ButtonByText(Preset.WEB32);
            public Element WIFIButton => ButtonByText(Preset.WIFI);
            public Element XKCDButton => ButtonByText(Preset.XKCD);
        }

        public _SettingsContainer SettingsContainer = new();
        public class _SettingsContainer
        {

        }

        public _GenerateContainer GenerateContainer = new();
        public class _GenerateContainer
        {
            public Element GeneratePasswordButton => new(By.Id, "generate_password_btn");
            public Element NumPasswordSelect => new(By.Id, "num_passwords");
            public Element GeneratedPasswordsTextarea => new(By.Id, "generated_password");
        }
    }
}
