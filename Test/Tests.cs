using NUnit.Framework;

namespace Test
{
    public class Tests : TestBase
    {
        [Test]
        [Category("Smoke")]
        [Description("Checkboxes default value")]
        public void CheckboxDefaultState()
        {
            View.Home.ClickLink("Checkboxes");

            Assert.IsFalse(View.Checkboxes.Checkbox1IsSelected());
            Assert.IsTrue(View.Checkboxes.Checkbox2IsSelected());
        }

        [Test]
        [Category("POC")]
        [Description("Checkbox value changes on click")]
        public void CheckboxesChangeValueOnClick()
        {
            View.Home.ClickLink("Checkboxes");

            View.Checkboxes.ClickCheckbox1();
            View.Checkboxes.ClickCheckbox2();
            Assert.IsTrue(View.Checkboxes.Checkbox1IsSelected());
            Assert.IsFalse(View.Checkboxes.Checkbox2IsSelected());
        }
    }
}
