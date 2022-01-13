using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoTestBase;

namespace _WebFramework.Views.Home
{
    public class CheckboxesView : BaseView
    {
        private CheckboxesViewElements Elements { get; } = new CheckboxesViewElements();
        public CheckboxesView(WebDriver driver) : base(driver) { }

        public void ClickCheckbox1() => Actions.Click(Elements.Checkbox1);
        public void ClickCheckbox2() => Actions.Click(Elements.Checkbox2);
        public bool Checkbox1IsSelected() => Actions.IsSelected(Elements.Checkbox1);
        public bool Checkbox2IsSelected() => Actions.IsSelected(Elements.Checkbox2);
    }
}
